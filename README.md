# R2Y Content Management Web API

#### In order to create a new migration you have to run the following commands

> dotnet ef migrations add Initial -p DataAccess -s WebApi

<br>

#### Execute the following commands to update the database
> dotnet ef database update -p DataAccess -s WebApi -- --environment Development

<br>

#### Execute the following commands to remove a migrations from project
> dotnet ef migrations remove -p DataAccess/ -s WebApi

#### There is a docker-compose file in the project, if you want to run the project with a local database you can run the following command

> docker-compose up --build

### If its not the first time running the project in docker-compose you can just run:

> docker-compose up