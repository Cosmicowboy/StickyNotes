using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using StickyNotes.Models;
using StickyNotes.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StickyNotes.ViewModels;

public partial  class MainWindowViewModel : ViewModelBase
{
    public RelayCommand<Window> WindowCloseCommand { get; private set; }
    public ObservableCollection<NotesContentModel> StickyNotesList { get; } = [];

    public MainWindowViewModel()
    {
        WindowCloseCommand = new RelayCommand<Window>(WindowClose);
        //TODO: check database for stored entries (daa access layer?)
    }
    
    //OpenSticky and New sticky should be combined 
        //need to figure out how to pass in either a blank model or one from the observ list
    private void OpenStickyNote(NotesContentModel item) 
    {
        var SavedNote = new StickyNoteViewModel(item);
        var NewNoteWindow = new StickyNoteView
        {
            DataContext = SavedNote,
            ShowInTaskbar = true
        };

        Window? owner = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime ? desktopLifetime.MainWindow : null;
        NewNoteWindow.Show(owner);
    }

    public void NewStickyNote()
    {
        var NewNoteModel = new NotesContentModel();
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

    private void WindowClose(Window notesList)
    {
        //TODO: Check if all child window (stickies) are closed
                //If not hide otherwise close the app.
        if (true) 
        {
            notesList.Hide();
        }
        else
        {
            notesList.Close();
        }        
    }

    //TODO: Handle light to dark shift
        //switch main window color to dark/light theme 
        //do through list of open stickies and change to dark/light
}