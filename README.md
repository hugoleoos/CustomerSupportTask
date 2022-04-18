# Customer Support Contacting - Arvato

This project aims to create a public form contacting customer support. Although the project was a simple task, I tried to show some knowledge in software development using .net Core, .net Core MVC and some concepts in software  design.

## 📋 The Approach 

First of all, the approach I used to solve this task was to create five projects responsible for the entire backend layer being one of them a webAPI, and two more projects responsible for my frontend layer being a web site. The idea of doing it this way was that if this solution needed high availability I could separately scale both layer (backend and frontend). For this reason I decided to develop the software this way and not create a standard MVC application. Also, the backend layer can be made available for other platforms.

## 🚀 About The Project

### 🔧 Backend

On the backend I used domain driven design principle and code first model, once it was a new project with no created database. So, in this project the idea was make the model first, then I create the database from it.
Using this approach, I created five Projects. Follow below some their characteristics:

* Arvato.Domain

This class library project is responsable for the application domain. 
Another important point here is that I used fluent mapping and fluent validation applying the "Single Responsibility" principle of SOLID where my domain classe (CustomerSupport) is responsible only by domain.
  - CodeFirst
  - Adapters (interface)
  - Fluent Validation
  - Exceptions
 
* Arvato.Business
 This class library project is responsable for all business rules.
  - IoC / Dependency injection
  - Business rules
  - Logging
  - Error Handling
 
* Arvato.DBAdapter
This class library project  is the application repository.
  - Fluent Mapping
  - Entityframework
  - Migrations
  - Dependency Injection
 
* Arvato.Business.Test
this class library project is responsable for unity tests. Here, I created some tests cases to test the business layer.

* Arvato.WebAPI
This webApi project is restful API service with method to create new customer support contact and get customer support contact by ID.

### 📄 FrontEnd

On the frontend, a form was created with the fields first and last name, email, phone, number, type of inquiry, a description of the support issue and an agreement checkbox. The frontend layer it validates if the mandatory fields are filled and sends these fields to the backend.

* ArvatoFront.ArvatoApi.Adapter
This project is responsible for making requests in the backend.
  - Dependency Injection
  - Refit

* ArvatoFront.
This project is responsible for displaying the fields (view) first and last name, email, phone, number, type of inquiry, a description of the support issue and an agreement checkbox, for the user to fill in the information and create the customer support contact. 
As in the backend layer, this project also validates the required fields.
 - bootstrap
 - HTML
 - CSS
 - Javascript

## ⚙️ Running the project 
This project is prepared to run both in memory and in a SQL Server database.

### 📦 In Memory
Running the project in memory you just need to download the source code from www.www.www.LINK and run it in visual studio.

### 🛠️ In Database
The database can be created automatically using Entityframework.
Running the project in a SQL Server database you need to follow the steps below:
```
Open powershell and install a dotnet ef with the following command "dotnet tool install --global dotnet-ef"
Change the String Connection in the appSettings
Execute the following command to create the Migrations folder in the Arvato.DBAdapter (follow this step just if the folder does not exists) "dotnet ef Migrations add InitialCreation"
Execute the following command to create a data structure in your database.
```

## 📌 Notes
To improve this project you can:
 - create more tests case
 - validate the email and phone fields in the backend layer
 - add more logs in the application
 - provide a display screen of contacting customer support
