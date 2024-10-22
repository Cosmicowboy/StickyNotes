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

        if (Design.IsDesignMode)
        {
            NotesContent = new ObservableCollection<NotesContentViewModel>(new[]
            {
                new NotesContentViewModel() { Content = "Testing 1", LastModified = DateTime.Now },
                new NotesContentViewModel() { Content = "Testing 2", LastModified = DateTime.Now },
                new NotesContentViewModel() { Content = "Testing 3", LastModified = DateTime.MinValue }
            });
            
        }

    }

    [RelayCommand]
    private void OpenStickyNote(NotesContentViewModel item)
    {
        //TODO: Open sticky window and pass contents/ date modified into it.
    }

    private void WindowClose(Window notesList)
    {
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