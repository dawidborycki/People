FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

USER app
RUN echo $BUILDPLATFORM
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["People.WebApp/People.WebApp.csproj", "./"]
RUN dotnet restore "People.WebApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "People.WebApp/People.WebApp.csproj" -c $configuration -o /app/build
#RUN dotnet test "People.Tests" ; exit 0

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "People.WebApp/People.WebApp.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "People.WebApp.dll"]
