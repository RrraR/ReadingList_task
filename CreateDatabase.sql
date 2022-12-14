USE [master]
GO

/****** Object:  Database [ReadingListDB]    Script Date: 12/12/2022 9:49:33 PM ******/
CREATE DATABASE [ReadingListDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReadingList', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ReadingList.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReadingList_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ReadingList_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReadingListDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ReadingListDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ReadingListDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ReadingListDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ReadingListDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ReadingListDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [ReadingListDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ReadingListDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ReadingListDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ReadingListDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ReadingListDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ReadingListDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ReadingListDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ReadingListDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ReadingListDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ReadingListDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ReadingListDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ReadingListDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ReadingListDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ReadingListDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ReadingListDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ReadingListDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ReadingListDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ReadingListDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ReadingListDB] SET  MULTI_USER 
GO

ALTER DATABASE [ReadingListDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ReadingListDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ReadingListDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ReadingListDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ReadingListDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ReadingListDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [ReadingListDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ReadingListDB] SET  READ_WRITE 
GO

create table Authors
(
    Id         int identity
        constraint PK_Authors
            primary key,
    AuthorName nvarchar(100) not null
)
go

create table Genres
(
    Id        int identity
        constraint PK_Genres
            primary key,
    GenreName nvarchar(50) not null
)
go

create table Series
(
    Id         int identity
        constraint PK_Series
            primary key,
    SeriesName nvarchar(50)
)
go

create table Books
(
    Id          int identity
        constraint PK_Books
            primary key,
    Name        nvarchar(100) not null,
    Length      int           not null,
    Language    nvarchar(50)  not null,
    FK_AuthorId int           not null
        constraint FK_Books_Authors
            references Authors,
    FK_GenreId  int           not null
        constraint FK_Books_Genres
            references Genres,
    FK_SeriesId int
        constraint FK_Books_Series
            references Series
)
go

create table BooksOfUser
(
    Id                int identity
        constraint PK_BooksOfUser
            primary key,
    FK_BookId         int                                           not null
        constraint FK_BooksOfUser_Books
            references Books,
    ReadingPriority   int
        constraint DF_BooksOfUser_ReadingPriority default 1         not null,
    IsFinished        bit
        constraint DF_BooksOfUser_IsFinished default 0              not null,
    StartReadingDate  date
        constraint DF__BooksOfUs__Start__0F624AF8 default getdate() not null,
    FinishReadingDate date
)
go

create table UserCollections
(
    Id             int identity
        constraint PK_UserCollections
            primary key,
    CollectionName nvarchar(50)
        constraint DF_UserCollections_UserCollectionName default N'Default' not null
)
go

create table BooksOfUserToCollections
(
    Id              int identity
        constraint PK_BooksOfUserToCollections
            primary key,
    FK_CollectionId int
        constraint DF__BooksOfUs__FK_Co__245D67DE default 1 not null
        constraint FK_BooksOfUserToCollections_UserCollections
            references UserCollections,
    FK_BookOfUserId int                                     not null
        constraint FK_BooksOfUserToCollections_BooksOfUser
            references BooksOfUser
)
go


