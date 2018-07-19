using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsChat.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<TextChatViewModel> Messages { get; set; }

        public string TextEntry { get; set; }

        public ICommand SubmitMessageCommand { get; set; }

        public MainViewModel()
        {
            Messages = new ObservableCollection<TextChatViewModel>();
            Messages.Add(new TextChatViewModel() { Text = "Hello" });
            SubmitMessageCommand = new Command<string>(SubmitMessage);

            Device.StartTimer(TimeSpan.FromSeconds(5), ReceiveMessage);
        }

        bool ReceiveMessage()
        {
            var lastMessage = Messages.LastOrDefault();
            if (lastMessage != null && lastMessage.Direction != TextChatViewModel.ChatDirection.Incoming)
            {
                Messages.Add(new TextChatViewModel() { Direction = TextChatViewModel.ChatDirection.Incoming, Text = $"You said {lastMessage.Text}" });
            }
            return true;
        }

        private void SubmitMessage(string obj)
        {
            var x = new TextChatViewModel() { Direction = TextChatViewModel.ChatDirection.Outgoing, Text = obj };
            Messages.Add(x);
            TextEntry = string.Empty;
        }
    }
}
