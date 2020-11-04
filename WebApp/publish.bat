del *.zip
rmdir /Q /S site
dotnet publish -o site -r linux-x64 --self-contained false
cd site
zip -r ../site.zip *
cd ..
zip WebApp.zip site.zip aws-windows-deployment-manifest.json
