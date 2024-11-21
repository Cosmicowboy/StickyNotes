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
    
    //pass in content through constructor 
    [RelayCommand]
    private void OpenStickyNote(StickyNoteViewModel item) 
    {
        //new stickyNoteview 
            //pass in the 
    }

    public void NewStickyNote()
    {
        var NewNoteModel = new NotesContentModel();

        StickyNotesList.Add(NewNoteModel);
        //TODO: Pass the model ref into the viewmodel? 

        var NewNote = new StickyNoteViewModel();
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
}