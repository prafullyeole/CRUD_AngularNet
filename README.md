# Application Details
Web application to do basic CRUD operation for contact entity, application contain following functionality

1) Search Contact
2) Add/Edit/Delete Contact
3) Change Contact Status
4) Remove All Contact

# Prerequisite
Developer must have basic knowlege of following 

1) Angular V9 Or V10
2) .Net Core (V3.1)
3) EF core
4) Depedency Injection
5) SQL Database
6) Auto Mapper
7) Mock
8) XUnit

# Project Strcuture

* Angular Application
* Web API
* Service Layer
* Repository Layer (EF Core)
* Entity Layer 
* Unit Test (xUnit)

# How to run application

1) Donwload code 
2) Open EvolContactApp.sln file in Visual Studio 2017 Or 2019
3) Clean and Build 
4) Change SQL connection string from ContactWebApi\appsettings.json
5) Run the migration on database using below steps
    * Open Package Manager Console
    * Select Project Repository
    * Run command ===> update-database
6) Now Open ClientApp folder in either Visual Studio code or any EDI
7) Restore node packages using below command
   * npm install
8) Run Application using ng serve -o

## Diagram

https://github.com/amolg92/ContactWebAppProject/blob/master/ArchiDiagram.PNG

## Note

When run application make sure both Angular and Web API is running

