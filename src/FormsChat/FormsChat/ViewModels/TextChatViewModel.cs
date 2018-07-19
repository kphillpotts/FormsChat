using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsChat.ViewModels
{
    public class TextChatViewModel : BaseViewModel
    {
        public enum ChatDirection
        {
            Outgoing = 0,
            Incoming = 1
        }

        public string Text { get; set; }
        public ChatDirection Direction { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
