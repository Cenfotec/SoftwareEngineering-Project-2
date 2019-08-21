using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlDropdownListModel : CtrlBaseModel
    {

        public string Label { get; set; }
        public string ListId { get; set; }
        public string Service { get; set; }
        public string StyleClass { get; set; }
        public string ColumnDataName { get; set; }


        private string URL_API_LISTs = "http://localhost:54312/api";

        public string ListOptions
        {
            get
            {
                var htmlOptions = "";
                var lst = GetOptionsFromAPI();

                foreach(var option in lst)
                {
                    htmlOptions += "<option value='" + option.Value + "'>" + option.Description + "</option>";
                }
                return htmlOptions;
            }
            set
            {

            }
        }


        private List<OptionList> GetOptionsFromAPI()
        {
            var client = new WebClient();

            var listUrl = $"{URL_API_LISTs}/{Service}/{ListId}";

            var response = client.DownloadString(listUrl);
            var options = JsonConvert.DeserializeObject<List<OptionList>>(response);
            return options;
        }



        public CtrlDropdownListModel()
        {
            ViewName = "";
        }
    }
}