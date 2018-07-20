using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FormsChat.Renderers;
using FormsChat.iOS.Renderers;

[assembly: ExportRenderer(typeof(ChatEntry), typeof(ChatEntryRenderer))]
namespace FormsChat.iOS.Renderers
{
    class ChatEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.Ended += Control_Ended;
            
            //if (Element != null)
            //{
            //    Element.HeightRequest = 0;
            //}

            //UIKeyboard.Notifications.ObserveWillShow((sender, args) => {

            //    if (Element != null)
            //    {
            //        Element.HeightRequest = args.FrameEnd.Height;
            //    }

            //});

            //UIKeyboard.Notifications.ObserveWillHide((sender, args) => {

            //    if (Element != null)
            //    {
            //        Element.HeightRequest = 0;
            //    }

            //});
        }

        private void Control_Ended(object sender, EventArgs e)
        {
            Control.BecomeFirstResponder();
        }
    }
}