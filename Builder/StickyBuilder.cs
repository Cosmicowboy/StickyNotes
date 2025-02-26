using StickyNotes.Models;
using StickyNotes.Views;
using StickyNotes.Interfaces;
using StickyNotes.ViewModels;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia;

namespace StickyNotes.Builder
{
    public class StickyBuilder
    {

        private StickyNoteView StickyView = new();
        private StickyNoteViewModel? StickyDataContext;
        private IStickyContent StickyContent;

        public StickyBuilder()
        {
            StickyContent = new NotesContentModel { InEdit = true};                  
        }

        public StickyBuilder(IStickyContent stickyContent)
        {
            StickyContent = stickyContent;
            StickyContent.InEdit = true;
        }

        /// <summary>
        /// wraps notes content in a viewmodel
        /// </summary>
        public void WrapStickyContent()
        {
            StickyDataContext = new(StickyContent);
        }

        /// <summary>
        /// sets UI data context to constructed viewmodel
        /// </summary>
        public void SetDataContext()
        {
            StickyView.DataContext ??= StickyDataContext;
        }

        /// <summary>
        /// builds a sticky note sets the owner as main window and shows sticky
        /// </summary>
        public StickyNoteView BuildStickyNote()
        {
            //TODO: check if window was built right 
            MainWindowViewModel.StickyNotesList.Add(StickyContent);

            StickyView.Show();

            return StickyView;
        }

    }
}
