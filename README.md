🔞 Только для меня и Отделянова В. В. 🔞

(Загрузка пакетов)
Install-Package Microsoft.EntityFrameworkCore -version 9.0.0 
Install-Package Microsoft.EntityFrameworkCore.Tools -version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Design -version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Proxies -version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.SqlServer -version 9.0.0

(Загрузка базы данных)
 Scaffold-DbContext "Server=.\SQLEXPRESS01;Database=Bookmaster;Trusted_Connection=true;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

(Обновление БД)
 Scaffold-DbContext "Server=.\SQLEXPRESS;Database=DashboardDb;Trusted_Connection=true;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Force
