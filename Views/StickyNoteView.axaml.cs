using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace StickyNotes.Views;

public partial class StickyNoteView : Window
{
    public StickyNoteView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

    }
}