@ECHO OFF
del *.nupkg
.\nuget.exe pack .\JsonConfiger.debug.nuspec -OutputDirectory ..\..\LocalNuget -symbols
