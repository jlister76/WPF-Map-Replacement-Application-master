using System.Collections.Generic;


namespace FSV42_FullMapReplacement
{
    public class ComboBoxViewModel
    {
        public List<string> StateCollection { get; set; }

        public ComboBoxViewModel()
        {
            StateCollection = new List<string>()
            {
                "Texas",
                "Kentucky / Tennessee",
                "Mississippi"
            };
        }

        public string Item { get; set; }
    }


}
