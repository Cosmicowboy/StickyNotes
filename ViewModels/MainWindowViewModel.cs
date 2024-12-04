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

        if(!item.InEdit)
        {
            item.InEdit = true;
            var SavedNote = new StickyNoteViewModel(item);
            var NewNoteWindow = new StickyNoteView
            {
                DataContext = SavedNote,
                ShowInTaskbar = true
            };

            
            NewNoteWindow.Show();
        }
    }

    public void NewStickyNote()
    {
        var NewNoteModel = new NotesContentModel();
        NewNoteModel.InEdit = true;
        StickyNotesList.Add(NewNoteModel);

        var NewNote = new StickyNoteViewModel(NewNoteModel);
        var NewNoteWindow = new StickyNoteView
        {
            DataContext = NewNote,
            ShowInTaskbar = true
        };

        
        NewNoteWindow.Show();
    }

    private void WindowClose(Window notesList)
    {
        bool openEdits = false;
        foreach (var item in  StickyNotesList)
        {
            if (item.InEdit)
            {
                openEdits = true;
                break;
            }
        }
        if (openEdits)
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