

using System;

namespace StickyNotes.Interfaces
{
    internal interface IStickyContent
    {
        public string? Content { get; set; }

        public DateTime LastModified { get; set; }
    }
}
