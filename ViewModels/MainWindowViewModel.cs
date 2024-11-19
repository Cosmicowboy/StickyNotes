using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using StickyNotes.Models;
using System;
using System.Collections.ObjectModel;

namespace StickyNotes.ViewModels;

public partial  class MainWindowViewModel : ViewModelBase
{
    public RelayCommand<Window> WindowCloseCommand { get; private set; }
    public ObservableCollection<NotesContentViewModel> NotesContent { get; } = [];

    public MainWindowViewModel()
    {
        this.WindowCloseCommand = new RelayCommand<Window>(this.WindowClose);

    }
    
    //pass in content through constructor 
    [RelayCommand]
    private void OpenStickyNote(NotesContentViewModel item) //pass in interface instead for testing (IStickyContent)
    {
        //opens new window, main window is owner 
        //pass Notes Content into VM 
    }

    public void NewStickyNote()
    {
        var NewNote = new NotesContentViewModel();
        NotesContent.Add(NewNote);
        OpenStickyNote(NewNote);
    }

    private void WindowClose(Window notesList)
    {
        //if all stickies are closed then main window closes
        // otherwise it just hides it
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