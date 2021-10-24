# ImageGram
A system that allows you to upload images and comment on them. The project has swagger to help with API design and documentation.

### Migration commands when Db Scheme changes
Open a terminal in the Infrastructure project then type the following commands:

    dotnet ef --startup-project ../ImageGram/ migrations add <MigrationName>
    dotnet ef --startup-project ../ImageGram/ database update

### Persistence
The project uses SQLite. DB path can be configured in the `appsettings.json` file.

### Deployment
The project is Docker ready. Use Docker to deploy the solution into production.
