using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormsChat.iOS.Effects;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(TopPaddingWhenKeyboardAppearsEffect), "TopPaddingWhenKeyboardAppearsEffect")]
namespace FormsChat.iOS.Effects
{
    public class TopPaddingWhenKeyboardAppearsEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            UIKeyboard.Notifications.ObserveWillShow((sender, args) =>
            {
                if (Element != null)
                {
                    //((View)Element).Margin = new Thickness(0, 0, 0, args.FrameEnd.Height);
                    ((View)Element).TranslateTo(0, -args.FrameEnd.Height, 200);
                }
            });

            UIKeyboard.Notifications.ObserveWillHide((sender, args) =>
            {
                if (Element != null)
                {
                    //((View)Element).Margin = new Thickness(0);
                    ((View)Element).TranslateTo(0, 0, 200);
                }
            });

            //UIKeyboard.Notifications.ObserveDidChangeFrame((sender, args) =>
            //{
            //    ((View)Element).Margin = new Thickness(0, args.FrameEnd.Height, 0, 0);
            //});
        }

        protected override void OnDetached()
        {
            
        }
    }
}