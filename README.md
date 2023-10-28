# Aplikacja do zarządzanina proacownikami 

If you want check it online: 
https://178.235.60.107:5025/


Przeglądanie i dodawania pracowników z pliku xml

1. Copy and run EntityFrameworkCore\Update-Database
2. Add appsettings.json to project or www like

{
  "Google": {
    "ClientId": "",
    "ClientSecret": ",
    "CallBackPath": "signin-google"
  },
  "Facebook": {
    "AppId": "",
    "AppSecret": "",
    "CallBackPath": "signin-facebook"
  },
  "Microsoft": {
    "ClientId": "",
    "ClientSecret": "",
    "CallBackPath": "signin-microsoft"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}


3. Enjoy
 

facebook/google/microsoft login(but is only for show name and picture yet) only working localy need ssl certyficate to save connection on https
login working with every values


Main page

<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/b2ab00a7-29d7-4703-a9f9-45740880f348">
<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/05dcb785-32ae-41ce-a738-6ca1bd89e766">

Show employee

<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/1f651fe5-a603-4c4d-8cfd-5783da1e944e">
<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/e529a2f9-615f-43b8-bb92-8e8423b0cb6a">

Add from xml


<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/93d1dd1b-68ad-47d6-a00d-5f507d67ccdf">
<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/b217d881-223f-4786-8ef9-7bd84311425c">
<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/7cd089ca-4c9c-4ab2-9cac-d2a5f5d8a7e0">

Add user

<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/b45e9f92-5c61-408a-8f0d-a3c3522b5d58">
<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/49780419-df6f-4708-972b-dc3ba1dd90f3">



