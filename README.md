<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/b164a412-9682-46c0-afaa-ad5ba06d0c26"># Aplikacja do zarządzanina proacownikami 

If you want check it online: 
https://178.235.60.107:5025/


Przeglądanie i dodawania pracowników z pliku xml

1. Copy and run EntityFrameworkCore\Update-Database to create database (please commit contructor with parameters in fabricContext first)

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
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Default": ""
  }
}


3. Enjoy
 

facebook/google/microsoft login(but is only for show name and picture yet) only working localy need ssl certyficate to save connection on https
login working with every values


Main page

<img width="600" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/b2ab00a7-29d7-4703-a9f9-45740880f348">
<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/226fb562-6177-4714-b05e-20570522af66">


Show employee

<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/94e8fb80-7739-478f-b9d2-924ce5510baa">
<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/4ab95255-7689-46aa-a7f8-e99916408d88">


Add from xml

<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/bca0c61c-c478-45d9-81d5-085f3cb286dd">
<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/ecfcaf3e-9b2e-43b2-8a13-cba8b406dc1d">
<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/b01ec771-0d62-4d01-a76e-610affb39a4b">
<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/c9327ec4-a55b-4f6f-967c-828f4104c0c8">


Add user

<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/f0135ec3-690a-458d-b870-f0d17c5437fa">
<img width="1920" alt="image" src="https://github.com/Maniek13/MenageEmployeeBlazor/assets/47826375/9b2eb1f1-2c39-4721-92a0-c6906ec60c1d">




