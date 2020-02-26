# Coding Exercise

## How to launch: 
### Things that need to be setup before launching. 

1. Install node_module into the FreshyCartApp folder. 
    1. Launch Command Prompt
    2. Navigate to the location of the CodingAssessmentApp folder of the project. 
    3. run 'npm install'
2. Create a local database called CodingAssessmentDB. *the sql script is already included in the zip folder and this repository*
3. Update the appsettings.json file in both CodingAssessmentDAL and CodingAssessmentWebAPI folder
"ConnectionStrings": {
    "DBConnectionString": "data source=server name;initial catalog=CodingAssessmentDB;Integrated Security=true"
  }
4. paste your own database server name at where it says 'server name' in that connection string. 

### Launch Data Access Layer and Web API Project

1. Open the solution file(.sln) in Visual Studio (I used Visual Studio 2019 community edition.)
2. Set the CodingAssessmentWebAPI as the starter project by right clicking and clicking 'Set as StartUp Project'
3. Build solution
4. Start project without debugging.  

### Launch Angular Project
1. Launch Command Prompt
2. Navigate to the location of the CodingAssessmentAppfolder. 
3. Type 'ng serve --open' and press ENTER.
4. It should launch your default web browser and display the frontend, you should see the login page at the landing page.

## Assumptions about the requirements.
1. At glance I assumed that the coordinators and attendees will have different layout as far as the frontend is concerned. 

## Components
1. login-user - takes care of validating a user. It only proceeds to the next page if the provided credentials exist in the database. 
2. view-events - displays all the on going events in tabular format.
3. add-new-events - this components display a form that lets a coordinator add a new event in the view-events components.
4. home - this component display the navigation bar displayed at the top of the viewEvents and addNewEvents page. It easily lets someone navigate between pages. 

## Service
1. coding-assessment.service.ts - this is where the API that we created in the WebAPI project gets consumed. 

## Interfaces
1. Users.ts - Represents the Users table in the database.
2. EventList.ts - A model of the EventList table in the database. 

