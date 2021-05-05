FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

COPY *.sln .
COPY ["Template.Project.WebApi/Template.Project.WebApi.csproj", "Template.Project.WebApi/"]
COPY ["Template.Project.CrossCutting/Template.Project.CrossCutting.csproj", "Template.Project.CrossCutting/"]
COPY ["Template.Project.Domain/Template.Project.Domain.csproj", "Template.Project.Domain/"]
COPY ["Template.Project.Util/Template.Project.Util.csproj", "Template.Project.Util/"]
RUN dotnet restore

COPY . .
WORKDIR "/source"
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Template.Project.WebApi.dll"]