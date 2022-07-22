dotnet tool install --global dotnet-ef
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
dotnet add package Microsoft.EntityFrameworkCore.Design

// ================================
dotnet ef migrations add changeModel01 -- context MedicineContext
dotnet ef database update --context MedicineContext