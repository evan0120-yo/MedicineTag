dotnet tool install --global dotnet-ef
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
dotnet add package Microsoft.EntityFrameworkCore.Design

<!-- ================================ -->
<!-- 更新Migrations -->
dotnet ef migrations add init -- context MedicineContext
<!-- 更新DataBase -->
dotnet ef database update --context MedicineContext

AutoMapper.Extensions.Microsoft.DependencyInjection


<!-- 相關網站 -->
<!-- track -->
https://docs.microsoft.com/zh-tw/ef/core/change-tracking/

https://docs.microsoft.com/zh-tw/dotnet/api/system.componentmodel.dataannotations?view=net-6.0

<!-- 刪除分支 -->
git branch -D issue1
<!-- 創建分支 -->
git checkout -b <new branch name>