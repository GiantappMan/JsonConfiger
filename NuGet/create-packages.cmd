@ECHO OFF
del *.nupkg
.\nuget.exe pack .\JsonConfiger.nuspec -OutputDirectory E:\mscoder\localNuget  -symbols
