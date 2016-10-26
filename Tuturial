# Entity Framework Tutorial

**DO NOT BUILD UNTIL YOU ARE TOLD TO DO SO**

- Open Visual Studio
- Create a New MVC Project named `Project1`
- Choose the MVC template so that JQuery and Bootstrap are automatically incorporated

### Create the Database

- Click on the View | SQL Server Object Explorer

  
  NOTE: You can use either the SQL Server Object Explorer or the Server Explorer

- Right click on SQL Server and choose Add SQL Server
- In the server name type (localDB)\V11.0
- Click on Connect


  NOTE: If this does not work, then you might have to use (localDB)\ProjectsV12 or (localDB)\ mssqllocaldb. 
    - (localdb)\ProjectsV12 instance is created by SQL Server Data Tools (SSDT)
    - (localdb)\MSSQLLocalDB is the SQL Server 2014 LocalDB default instance name
    - (localdb)\v11.0 is the SQL Server 2012 LocalDB default instance name

- Expand the (localDB)v11.0 item
- Right mouse click on Databases and choose Add New Database
- In the Database name type "Mission" and click on the OK button

  
  NOTE: The database is now created!
  

#### Create the tables

- Expand the Mission item
- Right mouse click on Tables and choose Add New Table
- In the Database name type Mission and click on the OK button
- Copy and paste the following script:
/**** MISSIONS TABLE ****/
```sql

CREATE TABLE [dbo].[Missions] (
    [missionID]       INT          IDENTITY (1, 1) NOT NULL,
    [missionName]     VARCHAR (50) NOT NULL,
    [missionPresName] VARCHAR (30) NOT NULL,
    [missionLanguage] VARCHAR (30) NOT NULL,
    [missionClimate]  VARCHAR (30) NOT NULL,
    [missionReligion] VARCHAR (30) NOT NULL,
    [missionImg]      VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([missionID] ASC)
);
```


  NOTE: You could also use the Design window instead of typing a SQL script

- Click on the Update tab
- Click on the Update Database button	NOTE: The table is now created
- Repeat this process for the following table structures:

```sql
CREATE TABLE [dbo].[Player]
(
  [playerID] INT NOT NULL PRIMARY KEY, 
  [playerLastName] VARCHAR(30) NOT NULL, 
  [playerFirstName] VARCHAR(30) NOT NULL, 
  [positionCode] VARCHAR(2) NOT NULL, 
  [teamID] INT 
)

/****** USERS TABLE*******/
CREATE TABLE [dbo].[Users] (
    [userID]    INT          IDENTITY (1, 1) NOT NULL,
    [userEmail] VARCHAR (50) NOT NULL,
    [userPass]  VARCHAR (30) NOT NULL,
    [userFirst] VARCHAR (20) NOT NULL,
    [userLast]  VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);
/****** MISSION QUESTIONS TABLE ********/
CREATE TABLE [dbo].[MissionQuestions] (
    [MissionQuestionId] INT           IDENTITY (1, 1) NOT NULL,
    [missionID]         INT           NOT NULL,
    [UserID]            INT           NOT NULL,
    [missQuestion]      VARCHAR (MAX) NOT NULL,
    [missAnswer]        VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([MissionQuestionId] ASC)
);
```



#### Get Connection String

- Get the connection string by clicking on the NBA Database and then using the properties window and searching for Connection String
- Click on the entry and press CTRL C to copy
- It should look something like:

```xml
Data Source=(localDB)\v11.0;Initial Catalog=Mission;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
```

#### Add the connection string to the Web.config file

- Go to the Web.config for the project
- In the connectionStrings section, add a connection with the name NBA and then paste in your connection string from the SQL Server object Explorer

```xml
 <add name="MissionContext" connectionString="Data Source=(localDB)\v11.0;Initial Catalog=NBA;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"
      providerName="System.Data.SqlClient" />
```

The provider is `providerName="System.Data.SqlClient"`

### Create the models for each table

- Now create the database model by right clicking the Models folder and choosing Add | Class
- Name the first model `Mission.cs`

#### Annotate the table and key

- Table identifies the database table and prevents pluralization while key specifies the primary key and overrides auto id (This means YOU will be responsible for entering the ID though so this all depends on what you are trying to accomplish)


```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FantasyBasketball.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int teamID { get; set; }
        public String teamName { get; set; }
    }
}
```

- Create the model for `Position.cs`

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    [Table("Missions")]
    public class Missions
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int missionID { get; set; }
        public String missionName { get; set; }
        public String missionPresName { get; set; }
        public String missionLanguage { get; set; }
        public String missionClimate { get; set; }
        public String missionReligion { get; set; }
        public String missionImg { get; set; }
       
    }
}
```

- Create the model for Player.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    [Table("Users")]
    public class Users
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        public String userEmail { get; set; }
        public String userPass { get; set; }
        public String userFirst { get; set; }
        public String userLast { get; set; }


    }
}
```

- NOTE: I can set up navigational properties if I wanted by identifying the foreign key adding virtual references to the foreign tables
 - Now we are setting up the mission questions table that will pull a mission from missions and a user from users so we need foreign keys
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int missionQuestionID { get; set; }
        public String missQuestion { get; set; }
        public String missAnswer { get; set; }
        [ForeignKey("Missions")]
        public virtual int missionID { get; set; }
        public virtual Missions Missions { get; set; }
        [ForeignKey("Users")]
        public virtual int userID { get; set; }
        public virtual Users Users { get; set; }

    }
}
```

### Modify the Global.asax.cs file

- Modify the Global.asax.cs file by adding the following:
	- System.Data.Entity
	- Database.SetInitializer<dbcontextname from the connectionstring>(null)
	- Projectname.Models;


NOTE: the dbcontext name is the same name as the connection string name. We will soon create the actual dbcontext variable. Don’t worry about the error messages for now.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Project1.Models;
using Project1.DAL;

namespace Project1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<MissionContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
```

### Create the DbContext variable

- Add a new folder to the project called `DAL`
- Add a new class to this folder called `MissionContext.cs`
- NOTE: This is the name of your dbContext variable and string in the connection string (web.config)


```csharp
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext()
            : base("MissionContext")
        {

        }

        public DbSet<Missions> Missions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<MissionQuestions> MissionQuestions { get; set; }
    }
}
```


NOTE: Make sure you resolve all errors (right-mouse click and choose resolve)


**BUILD the project**


### Create your scaffolded controllers and views for Player, Position, Team

- Save and build the project
- Run the project


### AFTER you have created all the tables and databases and clicked "build" project

Then you can have it auto-create your views and your controllers. 
Just right click on the controllers folder, click add > new scaffolded item
Click " MVC Controller with views using entity framework"
Then select which model and which database table to create one for
you have to do these one at a time. so select the missions table and the mission class
then add a new one and select the users table and the users class
then add one more and select the MissionQuestions class and mission questions table

### Now you can see if it works
Run your website, type /missions at the end of the url to see if it connect to a table. Try clicking create and make a new mission
The same thing should work with /users and /missioQuestions



