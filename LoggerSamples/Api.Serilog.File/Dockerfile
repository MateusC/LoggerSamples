FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Api.Serilog.File/Api.Serilog.File.csproj", "Api.Serilog.File/"]
RUN dotnet restore "Api.Serilog.File/Api.Serilog.File.csproj"
COPY . .
WORKDIR "/src/Api.Serilog.File"
RUN dotnet build "Api.Serilog.File.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Api.Serilog.File.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.Serilog.File.dll"]