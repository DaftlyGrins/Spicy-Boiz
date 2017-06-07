Instructions for accessing the website:
Due to issues with initialising the database on local hosts, in order to view the website, you'll have to access it via the public hosted version on Azure:

http://davidsspicyproperties.azurewebsites.net/

The website can be hosted locally, but anything related to the databases that it associates with will cause it to crash. Also, depending on your browser and PC, the Langversion in the webconfig file may need to be changed to 5 or 6 as necessary.

Part of the code within the website consists of automated code stubs that are generated upon initialisation of the website in ASP.net. Code that the development team have contributed is spread amongst a number of the folders, and varies from altering these automatically generated code stubs, to writing completely new code as necessary. Relevant folders and their contents include:

Content Folder - Site.css - The backbone of all objects within the website. Specifies sizes and locations of objects as they are initialised.

Controllers folder - The backend of many of the websites links.

Migrations folder - Database related code.

Models folder - Account related code.

Views folder - The pages for the website. Any object that can be seen is represented in this folder.

