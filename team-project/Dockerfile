FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

#To clean cache 
ARG CACHEBUST=1
#
COPY ["PresentationLayer/PresentationLayer.csproj", "PresentationLayer/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["BusinessLayer/BusinessLayer.csproj", "BusinessLayer/"]
COPY ["DataAccessLayer/DataAccessLayer.csproj", "DataAccessLayer/"]
RUN dotnet restore "PresentationLayer/PresentationLayer.csproj"
COPY . .
WORKDIR "/src/PresentationLayer"
RUN dotnet build "PresentationLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PresentationLayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PresentationLayer.dll"]