using AutoMapper;
using ReadingList_task.Data.Entities;
using ReadingList_task.Services.ViewModels;

namespace ReadingList_task.WebApi;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<BooksOfUser, BookOfUserOverviewViewModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.FK_Book.Name))
            .ForMember(d => d.Author, o => o.MapFrom(s => s.FK_Book.FK_Author.AuthorName))
            .ForMember(d => d.ReadingPriority, o => o.MapFrom(s => s.ReadingPriority))
            .ForMember(d => d.IsFinished, o => o.MapFrom(s => s.IsFinished))
            .ForMember(d => d.Collections, o =>
                o.MapFrom(s => s.BooksOfUserToCollections.Select(x => new CollectionViewModel()
                {
                    Id = x.FK_Collection.Id,
                    Name = x.FK_Collection.CollectionName
                } )));

        CreateMap<BooksOfUser, BookOfUserViewModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.FK_Book.Name))
            .ForMember(d => d.Author, o => o.MapFrom(s => s.FK_Book.FK_Author.AuthorName))
            .ForMember(d => d.Length, o => o.MapFrom(s => s.FK_Book.Length))
            .ForMember(d => d.Language, o => o.MapFrom(s => s.FK_Book.Language))
            .ForMember(d => d.Genre, o => o.MapFrom(s => s.FK_Book.FK_Genre.GenreName))
            .ForMember(d => d.Series, o => o.MapFrom(s => s.FK_Book.FK_Series.SeriesName))
            .ForMember(d => d.IsFinished, o => o.MapFrom(s => s.IsFinished))
            .ForMember(d => d.ReadingPriority, o => o.MapFrom(s => s.ReadingPriority))
            .ForMember(d => d.Collections, o =>
                o.MapFrom(s => s.BooksOfUserToCollections.Select(x => x.FK_Collection.CollectionName)));


        CreateMap<Book, LibraryBookOverviewsViewModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Author, o => o.MapFrom(s => s.FK_Author.AuthorName));
        
        CreateMap<Book, LibraryBookViewModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.Author, o => o.MapFrom(s => s.FK_Author.AuthorName))
            .ForMember(d=>d.Length, o=>o.MapFrom(s=>s.Length))
            .ForMember(d=>d.Language, o=>o.MapFrom(s=>s.Language))
            .ForMember(d=>d.Genre, o=>o.MapFrom(s=>s.FK_Genre.GenreName))
            .ForMember(d=>d.Series, o=>o.MapFrom(s=>s.FK_Series.SeriesName))
            .ForMember(d=>d.UserBookId, o=>o.MapFrom(s=>s.BooksOfUsers.Id));

        // CreateMap<BookOfUserViewModel, BooksOfUser>()
        //     .ForMember(d => d.FK_BookId, o => o.MapFrom(s => s.Id))
        //     .ForMember(d => d.ReadingPriority, o => o.MapFrom(s => s.ReadingPriority));
        

        CreateMap<UserCollection, CollectionViewModel>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.CollectionName));


    }
}