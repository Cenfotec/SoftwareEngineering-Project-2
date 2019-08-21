namespace WebApp.Models.Controls
{
    public class CtrlModalButtonModel : CtrlButtonModel
    {
        public string DataToggle { get; set; }
        public string DataTarget { get; set; }
        public string DataDismiss { get; set; }
        public string AriaLabel { get; set; }

        public CtrlModalButtonModel() : base()
        {

        }
    }
}