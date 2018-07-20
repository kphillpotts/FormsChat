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

[assembly: ExportRenderer(typeof(BoxViewKeyboardHeight), typeof(BoxViewKeyboardHeightRenderer))]
namespace FormsChat.iOS.Renderers
{
    public class BoxViewKeyboardHeightRenderer : BoxRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                Element.HeightRequest = 0;
            }

            UIKeyboard.Notifications.ObserveWillShow((sender, args) => {

                if (Element != null)
                {
                    Element.HeightRequest = args.FrameEnd.Height;
                }

            });

            UIKeyboard.Notifications.ObserveWillHide((sender, args) => {

                if (Element != null)
                {
                    Element.HeightRequest = 0;
                }

            });
        }
}
}