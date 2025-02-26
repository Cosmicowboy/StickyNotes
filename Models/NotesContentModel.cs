using StickyNotes.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using ReactiveUI;

namespace StickyNotes.Models
{
    public class NotesContentModel : ReactiveObject, IStickyContent
    {
        public NotesContentModel() 
        {
            LastModified = DateTime.Today;
        }

        private string? _content;
        public string? Content 
        {
            get => _content;
            set
            {
                this.RaiseAndSetIfChanged(ref _content, value);
            }
        }

        public DateTime LastModified { get; set; }

        public bool InEdit { get; set; }

    }
}
