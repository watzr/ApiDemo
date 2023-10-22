Scaffolding:

1. Install EF Core Design package in GoogleApiDemo project (Startup project).

2. Install EF Core SQL Server and EF Core Tools in ModelsLibrary.

3. Run the following command in GoogleApiDemo project.
   Added "Encrypt=False;" for windows authentication.

   Scaffold-DbContext "Data Source=<server_name>;Initial Catalog=<database_name>;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir YouTubeModels -Project ModelsLibrary