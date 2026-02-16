# Update-EFClasses.ps1
param(
    [string]$ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TrackingMyself;Integrated Security=True;Encrypt=True;TrustServerCertificate=False;Command Timeout=0",
    [string]$Provider = "Microsoft.EntityFrameworkCore.SqlServer",
    [string]$OutputDir = "Models",
    [string]$ContextDir = "Data",
    [string]$ContextName = "TrackingMyselfDbContext",
    [string]$Project = "EntityFramework.csproj",
    [string]$StartupProject = "EntityFramework.csproj"
)

Write-Host "Actualizando clases de Entity Framework..." -ForegroundColor Cyan

if (-not (Get-Command dotnet-ef -ErrorAction SilentlyContinue)) {
    dotnet tool install --global dotnet-ef
}

dotnet ef dbcontext scaffold `
    "$ConnectionString" `
    $Provider `
    --output-dir $OutputDir `
    --context-dir $ContextDir `
    --context $ContextName `
    --force `
    --project $Project `
    --startup-project $StartupProject

Write-Host "Clases actualizadas correctamente." -ForegroundColor Green