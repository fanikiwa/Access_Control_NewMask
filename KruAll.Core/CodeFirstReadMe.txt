Open Package Manager Console in visual studio.

Tools –> Library Package Manager –> Package Manager Console.

Run the Enable-Migrations command in Package Manager Console.
This command adds a Migrations folder to our project.
 
Run the Add-Migration command in Package Manager Console.
This command will scaffold the next migration based on changes you have made to your model since the last migration was created.

Run the Update-Database command in Package Manager Console.
This command will apply any pending migrations to the database.