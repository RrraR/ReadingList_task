insert into Authors (AuthorName)
values ('Neil Gaiman'),
       ('Terry Pratchett'),
       ('Stephen King'),
       ('Edgar Allan Poe'),
       ('J. K. Rowling'),
       ('J. R. R. Tolkien'),
       ('Arthur Conan Doyle');

insert into Genres (GenreName)
values ('Urban Fantasy'),
       ('Fantasy'),
       ('Horror fiction'),
       ('Horror'),
       ('Detective');

insert into Series (SeriesName)
values ('London Below, The World of Neverwhere Series'),
       ('Discworld Series'),
       ('Sherlock Holmes Series'),
       ('The Lord of the Rings Series'),
       ('Harry Potter Series');

insert into Books (Name, Length, "Language", FK_AuthorId, FK_GenreId, FK_SeriesId)
values ('Neverwhere', 448, 'English', 1, 1, 1),
       ('Pyramids', 341, 'English', 2, 2, 2),
       ('A Study in Scarlet', 123, 'English', 7, 5, 3),
       ('The Fellowship of the Ring', 432, 'English', 6, 2, 4),
       ('The Two Towers', 448, 'English', 6, 2, 4),
       ('The Return of the King', 404, 'English', 6, 2, 4),
       ('The Hobbit', 366, 'English', 6, 2, 4),
       ('Harry Potter and the Philosophers Stone', 223, 'English', 5, 2, 5),
       ('Harry Potter and the Chamber of Secrets', 341, 'English', 5, 2, 5),
       ('Harry Potter and the Prisoner of Azkaban', 435, 'English', 5, 2, 5),
       ('Harry Potter and the Goblet of Fire', 734, 'English', 5, 2, 5),
       ('Harry Potter and the Order of the Phoenix', 912, 'English', 5, 2, 5),
       ('Harry Potter and the Half-Blood Prince', 652, 'English', 5, 2, 5),
       ('Harry Potter and the Deathly Hallows', 759, 'English', 5, 2, 5),
       ('It', 1116, 'English', 3, 4, null),
       ('The Black Cat ', 24, 'English', 4, 3, null)
;
insert into UserCollections (CollectionName)
values ('default'),
       ('favs');


insert into BooksOfUser (FK_BookId, ReadingPriority, IsFinished, StartReadingDate, FinishReadingDate)
values (1, 1, 1, '2022 - 12 - 10', '2022 - 12 - 10'),
       (7, 1, 0, '2022 - 07 - 11', null),
       (10, 0, 0, '2018 - 05 - 07', null),
       (4, 1, 0, '2022 - 12 - 06', null),
       (2, 0, 1, '2022 - 12 - 06', '2022 - 12 - 08');

