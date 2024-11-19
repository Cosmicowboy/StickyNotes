using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using StickyNotes.Models;
using System;
using System.Collections.ObjectModel;

namespace StickyNotes.ViewModels;

public partial  class MainWindowViewModel : ViewModelBase
{
    public RelayCommand<Window> WindowCloseCommand { get; private set; }
    public ObservableCollection<StickyNoteViewModel> StickyNotesList { get; } = [];

    public MainWindowViewModel()
    {
        this.WindowCloseCommand = new RelayCommand<Window>(this.WindowClose);
        //check database for stored entries
    }
    
    //pass in content through constructor 
    [RelayCommand]
    private void OpenStickyNote(StickyNoteViewModel item) //pass in interface instead for testing (IStickyContent)
    {
        //opens new window, main window is owner 
        //pass Notes Content into VM 
    }

    public void NewStickyNote()
    {
        var NewNote = new StickyNoteViewModel();
        StickyNotesList.Add(NewNote);
        OpenStickyNote(NewNote);
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