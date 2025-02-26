using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using StickyNotes.Builder;
using StickyNotes.Interfaces;
using StickyNotes.Models;
using StickyNotes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace StickyNotes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public RelayCommand<Window> WindowCloseCommand { get; private set; }
    //change to StickyNotesView?
    public static ObservableCollection<IStickyContent> StickyNotesList { get; set; } = [];

    public static List<StickyNoteView> OpenNotes = [];

    public MainWindowViewModel()
    {
        WindowCloseCommand = new RelayCommand<Window>(WindowClose);
        //TODO: check database for stored entries
        // make objects form stored entries 
            //add to StickyNotesList
    }
    

    public void OpenStickyNote(IStickyContent item) 
    {
        if(!item.InEdit)
        {
            var stickyBuilder = new StickyBuilder();

            stickyBuilder.WrapStickyContent();
            stickyBuilder.SetDataContext();

            OpenNotes.Add(stickyBuilder.BuildStickyNote());
        }
        else
        {
            //TODO find item view (window) and bring to front
        }
    }

    public void NewStickyNote()
    {
        var stickyBuilder = new StickyBuilder();

        stickyBuilder.WrapStickyContent();
        stickyBuilder.SetDataContext();

        OpenNotes.Add(stickyBuilder.BuildStickyNote());
    }


    private void WindowClose(Window notesList)
    {
        if (OpenNotes.Count > 0)
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