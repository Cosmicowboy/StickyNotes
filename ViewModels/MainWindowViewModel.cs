using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using StickyNotes.Models;
using System;
using System.Collections.ObjectModel;

namespace StickyNotes.ViewModels;

public partial  class MainWindowViewModel : ViewModelBase
{

    public ObservableCollection<NotesContentViewModel> NotesContent { get; } = [];

    public MainWindowViewModel()
    {
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
        //Open sticky window and pass contents/ date modified into it.
    }
}
