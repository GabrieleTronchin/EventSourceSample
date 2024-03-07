##Step1: 
dotnet tool install -g dotnet-stryker

##Step2: go on prj folder and run following commands
dotnet new tool-manifest
dotnet tool install dotnet-stryker
dotnet tool restore

#Step3: run stryker
dotnet stryker



