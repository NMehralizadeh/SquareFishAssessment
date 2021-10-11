FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src

COPY . .
RUN dotnet restore "./SquareFish.Assessment.API/SquareFish.Assessment.API.csproj" --configfile "./nuget.config"
WORKDIR "/src/SquareFish.Assessment.API"
RUN dotnet publish "SquareFish.Assessment.API.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "SquareFish.Assessment.API.dll", "--urls=http://0.0.0.0:5000"]