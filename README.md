# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 
The project has the objective to be used as a RP Platform, it has all the encesary functionalities to work with Products, and to make Reports about Sales

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
	1. First, clone the repository
	2. After that you have to create the database, so connect to your local SQL Server and run the script/script.txt file
	3. Also, to insert elements in your model to make the test, run the Insertar Elementos de Prueba.txt and the other two Procedures in the .txt files in script folder.
	4. Go to appsettings.json file and edit the ConnectionStrings, change the source by your SQL Server Connection source, and the user ID and password too.
	5. Now, you can run the project
2.	Software dependencies
	The dependencies used by this project are ASP.NET Core:
	1. Microsoft.EntityFrameworkCore.SqlServer version 8.0.3
	2. Microsoft.EntityFrameworkCore.Tools version 8.0.2
	3. Microsoft.VisualStudio.Web.CodeGeneration.Design 8.0.1
3.	Latest releases
	1.  v1.0.0 (2024/03/17)
		- The product template and controller is working as a CRUD, it has Create, Edit, Update and Delete properties
		- Product Page can show all the CRUD functionalities
		- Report Page can show Report of Sales and Report of Sales Tendency and can use Filters
4.	API references
	1. /Product? : Shows all Product List
	2. /Product?handler=Search (searchText) : Search every product that has searchText in its name
	3. /Product?handler=Create (Product) : Creates a new Product
	4. /Product?handler=Edit (Product): Edits a Product
	5. /Product?handler=Delete (idProduct): Dellete the Product with Id = IdProduct
	6. /Report : Show the report of sales by Employee and the Report of Tendendy os Sales
	7. /Report?year={year}: Shows the report of Sales by Employee in a specific year
	8. /Report?start_date={start_date}&end_date={end_date}&employee_id={id_employee}: show the tendendy of sales depending on a range of dates, and for a specific Employee

# Build and Test
TODO: Describe and show how to build your code and run the tests. 
1. First, clone the repository
2. After that you have to create the database, so connect to your local SQL Server and run the script/script.txt file
3. Also, to insert elements in your model to make the test, run the Insertar Elementos de Prueba.txt and the other two Procedures in the .txt files in script folder.
4. Go to appsettings.json file and edit the ConnectionStrings, change the source by your SQL Server Connection source, and the user ID and password too.
5. Now, you can run the project

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 
1. Fork the repository.
2. Clone the fork repository to your local computer.
3. Create a new branch for your contribution: `git checkout -b feature/new-feature`.
4. Make your changes and make the necessary commits: `git commit -m "Add new functionality"`.
5. Push your branch to your fork repository: `git push origin feature/new-feature`.
6. Create a new pull request from your fork branch to the main branch of the original repository.


If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)