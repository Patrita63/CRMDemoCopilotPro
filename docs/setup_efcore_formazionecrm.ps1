# Setup EF Core per FormazioneCRM (PowerShell)
# Eseguire dalla root della solution:
# C:\___github\patrita63\FormazioneCRM\CRMDemoCopilotPro\

# 1) Ripristina pacchetti
 dotnet restore

# 2) Installa/aggiorna tool EF Core (globale)
 dotnet tool update --global dotnet-ef

# 3) Crea migrazione iniziale (progetto Infrastructure, startup Web)
 dotnet ef migrations add InitialCreate `
   --project .\FormazioneCRM.Infrastructure\FormazioneCRM.Infrastructure.csproj `
   --startup-project .\FormazioneCRM.Web\FormazioneCRM.Web.csproj `
   --context FormazioneCRM.Infrastructure.Persistence.ApplicationDbContext `
   --output-dir Persistence\Migrations

# 4) Applica migrazione al database
 dotnet ef database update `
   --project .\FormazioneCRM.Infrastructure\FormazioneCRM.Infrastructure.csproj `
   --startup-project .\FormazioneCRM.Web\FormazioneCRM.Web.csproj `
   --context FormazioneCRM.Infrastructure.Persistence.ApplicationDbContext

# 5) Verifica build
 dotnet build
