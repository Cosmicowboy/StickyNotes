using CommunityToolkit.Mvvm.ComponentModel;
using StickyNotes.Models;
using System;

namespace StickyNotes.ViewModels;

public partial class NotesContentViewModel : ViewModelBase
{
    /// <summary>
    /// Property to display date of last edit
    /// </summary>
    [ObservableProperty]
    public DateTime _lastModified;

    /// <summary>
    /// Property to display sticky note text content
    /// </summary>
    [ObservableProperty]
    public string? _content;

    /// <summary>
    /// Constructor for no arguments
    /// <para>If no argument then date is set to DateTime.Today</para>
    /// </summary>
    public NotesContentViewModel()
    {
        _lastModified = DateTime.Today;
    }
    
    /// <summary>
    /// Constructor for passing in sticky notes that have information
    /// <para> Stickies retrieved from database or that are collapsed</para>
    /// </summary>
    /// <param name="item"></param>
    public NotesContentViewModel(NotesContent item)
    {
        //Init properties with given values
        Content = item.Content;
        LastModified = item.LastModified;
    }

    public NotesContent GetStickyNote()
    {
        return new NotesContent()
        {
            Content = this.Content,
            LastModified = this.LastModified
        };
    }

}
