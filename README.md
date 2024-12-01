To initialize project you need to do

  1-) Setup and open docker desktop  
  
  2-) Open the console and typing corresponding code in the main root( SGK_Web_Backend). Possibly: /Downloads/SGK_Web_Backend
  
      docker-compose up --build
  or you can also do open the compose.yml file and click green run button if you can use Intellij Rider. This also build your docker
  
  3-) You need to migrate entities. That's why open the terminal in ./SGK_Web_Backend/SGK_Web_Backend and type
  
    dotnet ef migrations add <migration commit message>
    
  4-) Project is ready, you can check program with postman.
  
