@ECHO OFF
del *.nupkg
.\nuget.exe pack .\JsonConfiger.debug.nuspec -OutputDirectory E:\mscoder\localNuget -symbols
