using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PickerCancelDemo.iOS.Renders;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace PickerCancelDemo.iOS.Renders
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            UpdateToolbar();
        }

        private void UpdateToolbar()
        {
            var toolbar = (UIToolbar)Control.InputAccessoryView;

            var cancelButton = new UIBarButtonItem("Cancel", UIBarButtonItemStyle.Done, delegate { Control.ResignFirstResponder(); });
            var doneButton = toolbar.Items[1];
            var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);

            var items = new[] { cancelButton, flexibleSpace, doneButton };

            toolbar.SetItems(items, false);
        }
    }
}