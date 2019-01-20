@ECHO OFF
del *.nupkg
.\nuget.exe pack .\JsonConfiger.nuspec -OutputDirectory ..\..\LocalNuget  -symbols
