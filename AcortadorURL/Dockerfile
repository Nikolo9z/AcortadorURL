FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY AcortadorURL.csproj ./
RUN dotnet restore "AcortadorURL.csproj"

COPY . ./
RUN dotnet publish "AcortadorURL.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "AcortadorURL.dll"]
