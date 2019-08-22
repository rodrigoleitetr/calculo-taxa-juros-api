FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["SoftPlanTest.TaxaDeJurosCalculoAPI/SoftPlanTest.TaxaDeJurosCalculoAPI.csproj", "SoftPlanTest.TaxaDeJurosCalculoAPI/"]
COPY ["SoftPlanTest.Lib/SoftPlanTest.Lib.csproj", "SoftPlanTest.Lib/"]
COPY ["SoftPlanTest.Model/SoftPlanTest.Model.csproj", "SoftPlanTest.Model/"]
RUN dotnet restore "SoftPlanTest.TaxaDeJurosCalculoAPI/SoftPlanTest.TaxaDeJurosCalculoAPI.csproj"
COPY . .
WORKDIR "/src/SoftPlanTest.TaxaDeJurosCalculoAPI"
RUN dotnet build "SoftPlanTest.TaxaDeJurosCalculoAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SoftPlanTest.TaxaDeJurosCalculoAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SoftPlanTest.TaxaDeJurosCalculoAPI.dll"]