pipeline{
    agent any
    stages{
        stage('Git-Checkout'){
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

			echo "sending code coverage report"
			mail to: 'kandarp.verma@gmail.com',
      			subject: "Status of pipeline: ${currentBuild.fullDisplayName}",
      			body: "${env.BUILD_URL} has result ${currentBuild.result}"
		}
	}
        
    }
}