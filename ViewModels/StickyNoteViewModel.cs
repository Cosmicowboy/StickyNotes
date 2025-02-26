using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using StickyNotes.Models;
using StickyNotes.Views;
using System;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using StickyNotes.Interfaces;
using StickyNotes.Builder;

namespace StickyNotes.ViewModels;

public partial class StickyNoteViewModel : ViewModelBase
{
    /// <summary>
    /// Constructor for passing in sticky notes that have information
    /// <para> Stickies retrieved from database or that are collapsed</para>
    /// </summary>
    /// <param name="item"></param>

    private string? notesText;
    public string NotesText
    {
        get
        {

            if(StickyNote.Content  == null)
            {
                return "";
            }
            return StickyNote.Content;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref notesText, value);
            StickyNote.Content = value;
        }
    }

    public RelayCommand<Window> NoteCloseCommand {  get; private set; }

    private IStickyContent StickyNote;

    public StickyNoteViewModel(IStickyContent item)
    {
        StickyNote = item;
        NoteCloseCommand = new RelayCommand<Window>(NoteClose);
    }                                 

    public void NewStickyNote()
    {
        var stickyBuilder = new StickyBuilder();

        stickyBuilder.WrapStickyContent();
        stickyBuilder.SetDataContext();

        MainWindowViewModel.OpenNotes.Add(stickyBuilder.BuildStickyNote());

    }

    public void NoteClose(Window stickyNoteWindow)
    {
        //kick this out to a demo class
        //handle closing and validating notes 
        if (string.IsNullOrWhiteSpace(StickyNote.Content))
        {
            MainWindowViewModel.StickyNotesList.Remove(StickyNote);
        }
        StickyNote.InEdit = false;

        //TODO: save note location for opening next time
        stickyNoteWindow.Close();

        MainWindowViewModel.OpenNotes.Remove((StickyNoteView)stickyNoteWindow);

        //currently closes app if main window is still open 
        //TODO: update to see if its hidden
        if(MainWindowViewModel.OpenNotes.Count <= 0)
        {
            Window? mainWindow = Application.Current?.ApplicationLifetime is
                                   IClassicDesktopStyleApplicationLifetime desktopLifetime ? desktopLifetime.MainWindow : null;
            
            mainWindow.Close();
        }
    }
}
 