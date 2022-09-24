# Introduction

Template to run Umbraco CMS alongside React with Server side rendering (SSR) capabilities.  
Each component of the solution can be run individually, and a docker-compose is provided for easy deployment online.

# Requirements

Ensure that you have the following configuration:
- .NET 6 framework is installed.
- Node v14.x or later is installed.
- Docker is installed (for building and running the solution in docker-compose)

*NB1: If you plan to work on the frontend of the application, it can be convenient to have Docker installed.*  
*NB2: If you are going to deploy the infrastructure as code, ensure to have Terraform installed on your local machine.*

# Overview

The solution is composed of 3 main parts:
- An Umbraco web application
- An Express server
- A React application

The Umbraco application is dependent on:
- The React application -> It should be built and exported to `wwwroot` prior to run the web app, so the React files can be served to the client.
- The Express server -> Since each request to a RenderController is making request to the Express server, it should then be running alongside the Umbraco application. Requests will otherwise result in a 404. 


# Build / run locally

## React application

The react app is configured with [Create-React-App](https://create-react-app.dev/) (CRA).

With the comand line:
> npm run build  

This will build the react application and export copy the output to the `./src/Umbraco.React.Ssr.Web/wwwroot` folder of our Umbraco application, so that our Umbraco web app can serve the files to the clients.
Since the hash is different for every change done on our React app, it also updates `./src/Umbraco.React.Ssr.Web/Views/Partials/_Head.cshtml` with the updated hash for the files to serve.

You can run the react app individually for development purpose with:
> npm run start  

## Express server

With the comand line:
> npm run build:server  
> npm run start:server  

This will build the server in the `./src/Umbraco.React.Ssr.FrontEnd/dist` folder and allow it to SSR our react app when Umbraco sends a request to it with the model as payload.

## Umbraco application

With Visual Studio, open the solution `./src/Umbraco.React.Ssr.sln`, build, run.  

Via command-line:
> dotnet restore  
> dotnet build  
> dotnet run  

**NB**: The umbraco application is dependent on the express server.  
If the express server is not running, then the request to the Umbraco application will return 404.

**NB**: This template is shipped with umbraco content and settings. To import them, use uSync from the Settings tab backoffice and run Import

## Docker-compose

With the comand line from the root folder:
> docker-compose up -d

To rebuild docker images:

- umbraco-web: 
  > docker build . -t umbraco-web

- express-ssr: 
  > docker build . -t umbraco-web

**NB**: Before building `umbraco-web`, the React application should be built and exported to `wwwroot` beforehand.  
**NB**: The React application relies on two environment variables at build time:
- REACT_APP_API_ENDPOINT > defaults to `http://localhost:7000/api/`
- REACT_APP_MEDIA_ENDPOINT > defaults to `http://localhost:7000`  

Keep this in mind if you plan to deploy the solution online and refer to [Create-React-App documentation](https://create-react-app.dev/docs/adding-custom-environment-variables/) for more info regarding environment variables.