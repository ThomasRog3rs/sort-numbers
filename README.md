# Sort Numbers Web App
This application allows users to input random numbers then will order them for the user and submit the results to a SQL database using EF.
This was the technical interview for my Job at [Promtek](https://www.promtek.com)

## Assumptions
- The JSON export does not need to automatically download in the browser
- I am considering if the form submits to the database and shows the record on the SortInputs index as telling the user it was successful
- I assume that I can use Methods built into the C# language, specifically LINQ to order numbers.

## Deployment - Azure
1.  Create a resource group for the project
1.  Create a SQL database with that resource group assigned
1.  Migrate database to the SQL database on azure
1.  Create an App Service with your same resource group
1.  Link App Service and Database in Azure Publish Profile
1.  Edit the publish profile to use Azure Database when published
1.  Publish the project
1.  Check it out at https://{appServiceName}.azurewebsites.net

### My live application

[https://sortnumbers.azurewebsites.net](https://sortnumbers.azurewebsites.net)
