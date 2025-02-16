

using System;

namespace StickyNotes.Interfaces
{
    public interface IStickyContent
    {
        public string? Content { get; set; }

        public DateTime LastModified { get; set; }

        public bool InEdit { get ; set; }
    }
}
