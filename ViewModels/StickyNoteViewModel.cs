using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using StickyNotes.Models;
using StickyNotes.Views;
using System;
using Avalonia;

namespace StickyNotes.ViewModels;

public partial class StickyNoteViewModel : ViewModelBase
{
    /// <summary>
    /// Property to display date of last edit
    /// </summary>
    [ObservableProperty]
    public DateTime _lastModified;

    /// <summary>
    /// Property to display sticky note text content
    /// </summary>
    [ObservableProperty]
    public string? _content;
    
    /// <summary>
    /// Constructor for passing in sticky notes that have information
    /// <para> Stickies retrieved from database or that are collapsed</para>
    /// </summary>
    /// <param name="item"></param>
    public StickyNoteViewModel(NotesContentModel item)
    {
        //Init properties with given values
        Content = item.Content;
        LastModified = item.LastModified;
    }

    public NotesContentModel GetStickyNote()
    {
        return new NotesContentModel()
        {
            Content = this.Content,
            LastModified = this.LastModified
        };
    }
    public void NewStickyNote()
    {
        var NewNoteModel = new NotesContentModel();

        //need ref to mainwindow
        StickyNotesList.Add(NewNoteModel);

        var NewNote = new StickyNoteViewModel(NewNoteModel);
        var NewNoteWindow = new StickyNoteView
        {
            DataContext = NewNote,
            ShowInTaskbar = true
        };

        Window? owner = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime ? desktopLifetime.MainWindow : null;
        NewNoteWindow.Show(owner);
    }
}
