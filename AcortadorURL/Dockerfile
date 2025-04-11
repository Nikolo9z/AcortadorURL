FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia SOLO el proyecto principal y restaura dependencias
COPY AcortadorURL.csproj ./
RUN dotnet restore "AcortadorURL.csproj"

# Copia todo lo demás y publica
COPY . ./
RUN dotnet publish "AcortadorURL.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "AcortadorURL.dll"]
