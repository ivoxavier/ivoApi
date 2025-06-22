#Packages

dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.*
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.*
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.*
dotnet tool install --global dotnet-ef --version 8.0.*

dotnet ef dbcontext scaffold "Server=127.0.0.1;Port=3306;Database=MARYKAY_REPORTS;User=root;Password=Qwerty123456;SslMode=None;" Pomelo.EntityFrameworkCore.MySql -o Models --context MKReportsDbContext --no-onconfiguring