FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201 AS build
WORKDIR /app

COPY AudiobookLibrary.Web/*.csproj ./AudiobookLibrary.Web/
COPY AudiobookLibrary.Core/*.csproj ./AudiobookLibrary.Core/
COPY AudiobookLibrary.Shared/*.csproj ./AudiobookLibrary.Shared/
COPY AudiobookLibrary.Client/*.csproj ./AudiobookLibrary.Client/
RUN dotnet restore ./AudiobookLibrary.Web/AudiobookLibrary.Web.csproj

COPY AudiobookLibrary.Web/. ./AudiobookLibrary.Web/
COPY AudiobookLibrary.Core/. ./AudiobookLibrary.Core/
COPY AudiobookLibrary.Shared/. ./AudiobookLibrary.Shared/
COPY AudiobookLibrary.Client/. ./AudiobookLibrary.Client/
WORKDIR /app/AudiobookLibrary.Web
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/AudiobookLibrary.Web/out ./
ENTRYPOINT ["dotnet", "AudiobookLibrary.Web.dll"]