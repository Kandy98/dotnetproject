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
                    bat """dotnet SonarScanner begin /k:KanvermaCoreProject /d:sonar.host.url=http://localhost:9000 /d:sonar.login="98c8246a752ec6ed8e41ff503125f7095413ab84" /d:sonar.cs.opencover.reportsPaths="./FirstCoreProject/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs"""
                    bat "dotnet build FirstSolution.sln"
                    bat """dotnet SonarScanner end /d:sonar.login="98c8246a752ec6ed8e41ff503125f7095413ab84"""
                }
            }
        }
        stage("Quality Gate") {
            steps {
              timeout(time: 5, unit: 'MINUTES') {
                  waitForQualityGate webhookSecretId: '1234'
                waitForQualityGate abortPipeline: true
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