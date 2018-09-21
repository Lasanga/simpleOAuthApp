# simpleOAuthApp
demonstrate a simple .net core app with oauth 2.0 azure active directory

## STEPS:
create an azure active directory in your azurer portal
create a .net core web application
select an authorization to the project(.net core) when setting up the project (select work category)

check the appsettings.json 
Set the following json values in your appsettings.json to config the azure Active directory

```json
 "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": {YOUR DOMAIN NAME}, //example.onmicrosoft.com
    "TenantId":{YOUR CLIENT SECRET KEY},
    "ClientId": {YOUR APPLICATION ID},
    "CallbackPath": "/signin-oidc"
  }
  
configure the launchSettings.json for the server 

 "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "https://{YOUR DOMAIN NAME}.azurewebsites.net", //REPLY URL OF YOU APPLICATION IN THE AZURE ACTIVE DIRECTORY EXCLUDING THE CALLBACKP ATH
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
```    
  *if localhost specify the ssl port*
  
  *note that an application will be registered to the active directory automatically for the localhost once the project is created by selecting an authorization once the project is setting up*
  
  to host the application with a separate url register an app in the active directory, provide an app name and sign-on url
  
  1. select the app created
  2. settings > reply urls > "https://{APP NAME}.azurewebsites.net/signin-oidc" > save
  4. settings > properties > App Id Uri > "https://{DOMAIN NAME}.onmicrosoft.com/{APP NAME}"
  5. settings > properties > lougout Url > "https://{APP NAME}.onmicrosoft.com/signout-oidc"
  
  ###### To Add users: 
  
  select the directory in azure portal > Users > add Users
  
  ###### To Add Roles:
  
  Select the application from the active directory > select manifest to edit 
  Add:-
  ```json
  "appRoles": [
    {
      "allowedMemberTypes": [
        "User"
      ],
      "displayName": "Writer",
      "id": "d1c2ade8-98f8-45fd-aa4a-6d06b947c66f",
      "isEnabled": true,
      "description": "Writers Have the ability to create tasks.",
      "value": "Writer"
    },
    {
      "allowedMemberTypes": [
        "User"
      ],
      "displayName": "Admin",
      "id": "81e10148-16a8-432a-b86d-ef620c3e48ef",
      "isEnabled": true,
      "description": "Admins can manage roles and perform all task actions.",
      "value": "Admin"
    }
  ]
  ```
###### To assign created roles to the users
  
1. Select active directory
2. Select Enterprise Application
3. Select the application //According to this app(oAuthAppV2)
4. select userrs and groups
5. select add user
6. add user with a specific role and save
  
*by now you can check whether user is in a specific role inside your application by, "User.isInRole("{ROLENAME}")*
 
  
