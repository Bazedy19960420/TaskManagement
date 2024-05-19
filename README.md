# TaskManagementproject:
<h2>onion Archticture</h2>
<h3>Logger:</h3>

-I used Nlog package to Log in a file.

-I Made an interface IloggerManager and that have the methods to log (info,warn,debug,error) that every method have one string parameter what i will log.

-then i implement it in loggerManger class i have made in Logger Service but before implementing it i installed NLog in (LoggerService) Project.
<hr/>
<h3>Database: Using Sqllite</h3>

-I create a new project (Entities) to put Task Entity Inside.

-I create a new project (Repositories) to put dbcontext inside.

-install EntityFrameWorkCore to deal with db creation.

-install Microsoft.EntityFrameworkCore.Sqlite package as it will be the provider.

-I put the connection string in appsetting.json . 

-I Register the Dependancy in Program.cs File .
<hr/>
<h3>Repository:</h3>
- create a Generic Repository to implement the base crud function ,i created interface (RepositoryBase) in (Contracts) project.

<p>-then implement it in (Repository) Project after i created the (RepositoryBase) Class</p>

-we will use RepositoryManager because it is good practise so if we want response from multible Resources we have to instaiate every repository for each resource we want so we use repository manager which will instaniate for us and make it in one transaction .
<hr />
<h3>Services:</h3>
- I created the services in corcern of seperation to deal with the presentation and with Repository so i created (Service) project and i put (TaskService)&(ManagerSrevice) classes in it.

<hr/>
<h3>cycle of Adding different Actions:</h3>
-we first create the query that we want from the database in TaskRepository then we Add the service Action that will deal with it the we create the method in the controller which will get it by injecting the service in the controller and the service will do the Action.
</hr>
<h3>Notes About the objects returned from service:</h3>
-we dont return the Entites that we made in database but we will introduce an intermediate between models and the objects DTO(Data Transafer Object) that we return because there is navigational properties in the models we created in the database and also those entites may have sensitive information
that we dont want to return in the response body.

-we will create project (Shared) to put DTO inside.

-we will use record for Dto because records create immutable refernce types that we can not change after initializtion it.

-then we use autoMapper to map the properties between the entity and the dto. 
<hr/>
<h3>Error Handling:</h3>

-I can use try catch in services but we will useExceptionHandling in the middleware.

-I create an (ErorrDetail)class to return its properties.

-then I creat an Extension Method to inject in middleware that return and log the error. 
</hr>
<h2>References:</h2>
-https://learn.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli

-https://www.linkedin.com/pulse/onion-architecture-arshad-shahoriar-r6ehc/

-https://code-maze.com/net-core-series/
