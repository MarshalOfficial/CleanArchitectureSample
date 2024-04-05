```
cd to Persistence project folder

dotnet tool install dotnet-ef -g

dotnet ef migrations add init --help

dotnet ef migrations add init -s ..\..\API\CleanArchitectureSample.Api\CleanArchitectureSample.Api.csproj

dotnet ef database update -s ..\..\API\CleanArchitectureSample.Api\CleanArchitectureSample.Api.csproj
```