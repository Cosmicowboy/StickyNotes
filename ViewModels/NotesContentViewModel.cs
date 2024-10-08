using CommunityToolkit.Mvvm.ComponentModel;
using StickyNotes.Models;
using System;

namespace StickyNotes.ViewModels;

public partial class NotesContentViewModel : ViewModelBase
{
    public NotesContentViewModel()
    {
        //Empty
    }

    public NotesContentViewModel(NotesContent item)
    {
        //Init properties with given values
        Content = item.Content;
        LastModified = item.LastModified;
    }

    [ObservableProperty]
    public DateTime _lastModified;

    [ObservableProperty]
    public string? _content;

    public NotesContent GetStickyNote()
    {
        return new NotesContent()
        {
            Content = this.Content,
            LastModified = this.LastModified
        };
    }

}
