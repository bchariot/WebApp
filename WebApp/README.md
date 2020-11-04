AWS Management Console

Services -> Elastic Beanstalk -> Create Application
- set application name
- choose Platform (.NET on Windows Server)
- Sample application
- Create application

Upload and Deploy
- choose file "WebApp.zip"
- version label: WebApp
- deploy

Create distribution:

C:\FSharp\WebApp\WebApp> ./publish.bat

- OR -

C:\FSharp\WebApp\WebApp> dotnet publish -o site
C:\FSharp\WebApp\WebApp> cd site
C:\FSharp\WebApp\WebApp\site> zip -r ../site.zip *
C:\FSharp\WebApp\WebApp\site> cd ..
C:\FSharp\WebApp\WebApp> zip WebApp.zip site.zip aws-windows-deployment-manifest.json

