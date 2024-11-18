using StickyNotes.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace StickyNotes.Models
{
    public class NotesContent : IStickyContent
    {
        public string? Content { get; set; }

        public DateTime LastModified { get; set; }

    }
}
