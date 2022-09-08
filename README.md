# Blog

## Description
This template provides a blogging platform based on .net 6, asp.net MVC.

The application uses efcore for data connection to sql Server.
Hangfire is used to process api calls to the old blog in the background on a hourly basis.

## Requirements and environment
1. Visual studio 2022
2. dotNet 6

## Setup Instructions
* Clone the repository
* Open the solution in visual studio.
Change the connection string in appsettings json
use the package manager console and run the migrations
```powershell
update-database
```
This is used to create the database specified in the connection string.
* The migration also seeds an admin user.
Register to view your posts and create new posts on the blog

