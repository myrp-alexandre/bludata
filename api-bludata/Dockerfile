FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as builder
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o ../out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=builder /app/out .
ENTRYPOINT ["dotnet", "api-bludata.application.webapi.dll"]
EXPOSE 80
EXPOSE 443