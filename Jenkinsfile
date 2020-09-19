#!groovy
pipeline { 
    agent any
    stages {
        stage('Preparation') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                bat "dotnet build"
            }
        }
        stage('Test') {
            steps {
                bat "dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover"
            
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv('sonarqube') {
                     
                    bat "dotnet build-server shutdown"
                    bat """dotnet SonarScanner begin /k:KanvermaCoreProject /d:sonar.host.url=http://localhost:9000 /d:sonar.login="4ef795f45bc5ed9cbea85bc28f601093a6c79ac7" /d:sonar.cs.opencover.reportsPaths="./FirstCoreProject/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs"""
                    bat "dotnet build FirstSolution.sln"
                    bat """dotnet SonarScanner end /d:sonar.login="4ef795f45bc5ed9cbea85bc28f601093a6c79ac7"""
                    
                }

                sleep time: 10, unit: 'SECONDS';
            }

        
        }
        
        stage("Quality Gate") {
            steps {
                /*timeout(time: 5, unit: 'MINUTES') {
                    waitForQualityGate abortPipeline: true
                }*/

                script {
          Integer waitSeconds = 10
          Integer timeOutMinutes = 10
          Integer maxRetry = (timeOutMinutes * 60) / waitSeconds as Integer
          for (Integer i = 0; i < maxRetry; i++) {
            try {
              timeout(time: waitSeconds, unit: 'SECONDS') {
                def qg = waitForQualityGate()
                if (qg.status != 'OK') {
                  error "Sonar quality gate status: ${qg.status}"
                } else {
                  i = maxRetry
                }
              }
            } catch (Throwable e) {
              if (i == maxRetry - 1) {
                throw e
              }
            }
          }
        }

            }
        }

        stage('Run') {
            steps {
                
                bat "cd FirstCoreProject"
                bat "dotnet run --project FirstCoreProject"
            }
        }
    }
    post {  
        always {  
            echo 'Build Result:'  
        }  
        success {  
            echo 'The .net build was successful !'  
        }  
        failure {  
            echo 'The .net build failed !'
        }    
    }
}