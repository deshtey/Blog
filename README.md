# Blog

## Description
This template provides a blogging platform based on .net 6, asp.net MVC.
The application uses efcore for data connection to sql Server.
Hangfire is used to process api calls to the old blog in the background on a hourly basis.

## Requirements and environment
Visual studio 2022
.Net 6

## Setup Instructions
Clone the repository
open the solution in visual studio.
Change the connection string in appsettings json
Run "update-database" in package manager console to create the database specified in the connection string.
The migration also seeds an admin user
Register to view your posts nad create new posts on the blog

