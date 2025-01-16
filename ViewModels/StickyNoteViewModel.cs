using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using StickyNotes.Models;
using StickyNotes.Views;
using System;
using Avalonia;
using CommunityToolkit.Mvvm.Input;

namespace StickyNotes.ViewModels;

public partial class StickyNoteViewModel : ViewModelBase
{
    /// <summary>
    /// Constructor for passing in sticky notes that have information
    /// <para> Stickies retrieved from database or that are collapsed</para>
    /// </summary>
    /// <param name="item"></param>

    public event EventHandler OnRequestClose;
    public RelayCommand<Window> NoteCloseCommand {  get; private set; }

    private NotesContentModel StickyNote;

    public StickyNoteViewModel(NotesContentModel item)
    {
        StickyNote = item;
    }                                 

    public void NewStickyNote()
    {
        var NewNoteModel = new NotesContentModel();

        //need ref to mainwindow
        //StickyNotesList.Add(NewNoteModel);

        var NewNote = new StickyNoteViewModel(NewNoteModel);
        var newNoteWindow = new StickyNoteView
        {
            DataContext = NewNote,
            ShowInTaskbar = true
        };

        Window? owner = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime ? desktopLifetime.MainWindow : null;
        newNoteWindow.Show(owner);

    }
    //TODO: 
    //throws ref error
    //noteWindow is null?
    // main window subscribe to events instead of this closing the window the main window closes it.
    public void WindowClose()
    {
        
        OnRequestClose(this, new EventArgs());
    }
}
