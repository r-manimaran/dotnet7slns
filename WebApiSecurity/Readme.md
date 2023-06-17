# Web API Security


## Broken Object Level Authorization
---
When the application is not handling to grant access only to the necessary objects, its consider the Broken Object level authorization(BOLA).

Consider I have a API endpoint as below which returns the User's account information.
https://localhost:443/api/Users/233

Here 233 is the userid. suppose a user predicted that the resource Users is accepting the user id and send a request with different
userid as below, will allow them to view the other User details with id 454. 
https://localhost:443/api/Users/454



