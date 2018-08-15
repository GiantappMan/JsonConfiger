@ECHO OFF
del *.nupkg
.\nuget.exe pack .\JsonConfiger.nuspec -symbols
