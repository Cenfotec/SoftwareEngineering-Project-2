namespace WebApp.Models.Controls
{
    public class CtrlButtonNoClassModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string FunctionName { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }

        public CtrlButtonNoClassModel()
        {
            ViewName = "";
        }
    }
}