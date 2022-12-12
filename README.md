# ReadingList_task

## About project
Projects acts as a book tracker. User can add books to personal library, edit start reading and finish reading date, mark the book as read and change reading priority. User can also crate and manage personal book collections.

## Confuguration

#### Frontend 
Frontend of the project is witten in react.  

In the project directory, you can run:

```bash
  npm start
```

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.


#### Backend
Backend is witten in c# using Web.Api and does not requre any additional settings

#### Database

This project uses MSSQL and MSSQL managment studio 18
1. Change database settings in [appsettings.json](https://github.com/RrraR/ReadingList_task/blob/master/ReadingList_task.WebApi/appsettings.json)

```csharp
  "ConnectionStrings": {"Default": "your string here"}
```
2. Run [CreateDatabase.sql](https://github.com/RrraR/ReadingList_task/blob/master/CreateDatabase.sql) file to create database and [FillDatabase.sql](https://github.com/RrraR/ReadingList_task/blob/master/FillDatabase.sql) to populate it.

3. Database structure

![Database structure](DatabaseDiagram.png?raw=true "Database Structure")


## Architecture

1. Project uses Repository-Service pattern

2. Project contains 4 layers:
 - [Frontend UI](https://github.com/RrraR/ReadingList_task/tree/master/readinglist.ui) - displays pages to user
 - [Api](https://github.com/RrraR/ReadingList_task/tree/master/ReadingList_task.WebApi) - controllers in this layer manage communications between Services and Frontend
 - [service layer](https://github.com/RrraR/ReadingList_task/tree/master/ReadingList_task.Services) - main function is to access repositories to manipulate data
 - [data access and repositories layer](https://github.com/RrraR/ReadingList_task/tree/master/ReadingList_task.Data) - has access to database and is used to get required data

 3. Entity Framework Core is used to communicate with database

 4. [View models](https://github.com/RrraR/ReadingList_task/tree/master/ReadingList_task.Services/ViewModels) are used to pass data between controller and Frontend
 5. [Queries](https://github.com/RrraR/ReadingList_task/tree/master/ReadingList_task.Services/Query) are used to implement fetures such as filter and edit book


## Project Features

- Add books to personal library
- Edit start date, finish date, reading priority and mark book as read
- Books not marked as read contain null in finish date
- Default value for start date and finish date when you add new book to your library is today
- Default value for reading priority on any new book you add is 1. You can change it from 1-10. 0 is reserved for books that are marked as finished
- Create personal collections and add books
