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
 




<img width="800" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/eb5a3c02-509c-42b5-8ad5-239e9f36c6ac">


<img width="800" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/5c3ec3e6-bb02-42c0-98af-07c17e93a703">


<img width="800" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/6bd7008a-9088-43ed-88e6-0292e20d8d0d">


<img width="800" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/aae7d000-a915-43dc-8f08-0210ada4437c">



-- 

add facebook/google/microsoft login(but is only for show name and picture yet) only working localy need ssl certyficate to save connection on https and it is only to show/no more action when login (working everythink becouse I don't have a certificate)

<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/425a5329-41d4-48e3-a760-fa4f4fbb56cd">



