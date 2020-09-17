pipeline{
    agent any
    
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
                    sh """
                    #!/bin/bash
                    dotnet build-server shutdown
                    echo 'hello world'
                    dotnet sonarscanner/sonar-scanner/SonarScanner.MSBuild.dll begin /k:FirstCoreProject /d:sonar.host.url=http://35.229.248.239:9000 /d:sonar.login="863375e933a566953f21126b24042bde76669dd7" /d:results.xml /d:sonar.coverage.exclusions=”**UnitTest*.cs”
                    dotnet build FirstCoreProject.sln
                    dotnet sonarscanner/sonar-scanner/SonarScanner.MSBuild.dll" end 
                    """
                }
            }
        }
    }
}