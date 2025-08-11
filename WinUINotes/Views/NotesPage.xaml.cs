using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using Windows.Storage;
using WinUINotes.Models;

namespace WinUINotes.Views
{
    public sealed partial class NotesPage : Page
    {

        private Note? noteModel;

        public NotesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Note note)
            {
                noteModel = note;
            }
            else
            {
                noteModel = new Note();
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (noteModel is not null)
            {
                await noteModel.SaveAsync();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (noteModel is not null)
            {
                await noteModel.DeleteAsync();
            }

            if (Frame.CanGoBack == true)
            {
                Frame.GoBack();
            }
        }
    }
}