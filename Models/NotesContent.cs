﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace StickyNotes.Models
{
    public class NotesContent
    {
        public string? Content { get; set; }

        public DateTime LastModified { get; set; }

    }
}
