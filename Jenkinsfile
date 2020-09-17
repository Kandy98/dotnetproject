pipeline{
    agent any

    environment {
        scannerHome = tool name:'sonarscanner'
        msbuild = tool name: 'MSBuild'
    }
    
    stages{
        stage('SCM'){
            steps{
                checkout scm
            }
        }

        stage('Build'){
            steps{
                echo "Building the project";
                bat "dotnet build";
	        	
            }
        }

        stage('Unit-Tests'){
            steps{
                echo "Running Xunit-Tests";
                bat "dotnet test";
                }
        }

	    stage('Code Coverage') {
		    steps {
                echo "Checking code covergae"
                bat """C:/Users/kanverma/.nuget/packages/opencover/4.7.922/tools/OpenCover.Console.exe -target:"C:/Users/kanverma/Documents/dotnet training/networkspace/FirstCoreProject/bin/Debug/netcoreapp3.1/FirstCoreProject.exe" -register:user"""
		    }
	    }

        stage('Build + SonarQube analysis') {
            steps {
                withSonarQubeEnv('localsonar') {
                    bat "dotnet build-server shutdown"
                    bat """${scannerHome}\\SonarScanner.MSBuild.exe begin /k:github-jenkins-sonar /d:sonar.sources="/" /d:sonar.cs.opencover.reportsPaths="results.xml" /d:sonar.coverage.exclusions="**Test*.cs"""
                    bat '{$msbuild}\\MSBuild.exe FirstSolution.sln /t:Rebuild /p:Configuration=Release'
                    bat "${scannerHome}\\SonarScanner.MSBuild.exe end"
                }
            }
        }
    }
}