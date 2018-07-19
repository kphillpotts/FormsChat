using FormsChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsChat
{
	public partial class MainPage : ContentPage
	{
        MainViewModel vm;

		public MainPage()
		{
            BindingContext = vm = new MainViewModel();
			InitializeComponent();


		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }



        private void Button_Clicked(object sender, EventArgs e)
        {
            var x = MessageListView.ItemsSource;
            MessageListView.ScrollTo(vm.Messages.Last(), ScrollToPosition.MakeVisible, false);


        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            MessageListView.ScrollTo(vm.Messages.Last(), ScrollToPosition.End, false);
            //EntryText.Focus();
        }

        private void EntryText_Focused(object sender, FocusEventArgs e)
        {
            MessageListView.ScrollTo(vm.Messages.Last(), ScrollToPosition.End, false);
        }
    }
}
