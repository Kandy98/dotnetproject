pipeline{
    agent any
    environment {
        scannerHome = tool name:'sonarscanner', type: 'hudson.plugins.sonar.MsBuildSQRunnerInstallation' 
        msbuild = tool name: 'MSBuild'
    }
    stages{
        stage('SCM'){
            steps{
                echo "Checking out from git repo";
                git url:"https://github.com/Kandy98/dotnetproject.git"
            }
        }

        stage('Restore-packages'){
            steps{
                echo "Preprocessing: Restore packages";
                bat "dotnet restore"
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
                echo "Running Junit-Tests";
                bat "dotnet test";
                }
        }

	    stage('Code Coverage') {
		    steps {
                bat """C:/Users/kanverma/.nuget/packages/opencover/4.7.922/tools/OpenCover.Console.exe -target:"C:/Users/kanverma/Documents/dotnet training/networkspace/FirstCoreProject/bin/Debug/netcoreapp3.1/FirstCoreProject.exe" -register:user"""
		    }
	    }

        stage('Build + SonarQube analysis') {
            steps {
                withSonarQubeEnv('localsonar') {
                    bat """${scannerHome}\\SonarScanner.MSBuild.exe begin /k:github-jenkins-sonar /d:sonar.scm.exclusions.disabled=true /d:sonar.cs.opencover.reportsPaths="results.xml" /d:sonar.coverage.exclusions="**Test*.cs"""
                    bat "dotnet build FirstSolution.sln"
                    bat "${scannerHome}\\SonarQube.Scanner.MSBuild.exe end"
                }
            }
        }
    }
}