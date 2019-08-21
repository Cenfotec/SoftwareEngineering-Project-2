using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Controls;

namespace WebApp.Helpers
{
    public static class ControlExtensions
    {

        public static HtmlString CtrlCheckBox(this HtmlHelper html, string viewName, string id, string idcb1, string idcb2, string label, string name, string value, string valueb, string placeholder)
        {
            var ctrl = new CtrlCheckBoxModel
            {
                ViewName = viewName,
                Id = id,
                IdCheckBox1 = idcb1,
                IdCheckBox2 = idcb2,
                Label = label,
                Name = name,
                Value = value,
                Valueb = valueb,
                Placeholder = placeholder
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlUserCard(this HtmlHelper html, string id, string nombre, string apellido)
        {
            var ctrl = new CtrlUserCardModel
            {
                Id = id,
                Nombre = nombre,
                Apellido = apellido
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlMap(this HtmlHelper html, string viewName, string id, string latitud, string longitud)
        {
            var ctrl = new CtrlMapModel
            {
                ViewName = viewName,
                Id = id,
                Latitud = latitud,
                Longitud = longitud
            };

            return new HtmlString(ctrl.GetHtml());
        }

        

        public static HtmlString CtrlDropDown(this HtmlHelper html, string id, string pClass, string selectId, string optionId = "", string columnDataName = "", string label = "")
        {
            var ctrl = new CtrlDropdownModel
            {
                Id = id,
                Class = pClass,
                SelectId = selectId,
                OptionId = optionId,
                ColumnDataName = columnDataName,
                Label = label
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDownList(this HtmlHelper html, string id, string pClass, string service, string listId, string columnDataName = "", string label = "")
        {
            var ctrl = new CtrlDropdownListModel
            {
                Id = id,
                StyleClass = pClass,
                ListId = listId,
                Service = service,
                ColumnDataName = columnDataName,
                Label = label
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDownTags(this HtmlHelper html, string id, string label, string name)
        {
            var ctrl = new CtrlDropdownTagsModel
            {
                Id = id,
                Label = label,
                Name = name
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTimePicker(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName = "")
        {
            var ctrl = new CtrlTimePickerModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlInputHidden(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName = "")
        {
            var ctrl = new CtrlInputHiddenModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }


        public static HtmlString CtrlImage(this HtmlHelper html, string viewName, string id, string idButton)
        {
            var ctrl = new CtrlImageModel
            {
                ViewName = viewName,
                Id = id,
                IdButton = idButton
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlHeaderButton(this HtmlHelper html, string id, string label, string link)
        {
            var ctrl = new CtrlHeaderButtonModel
            {
                Id = id,
                Label = label,
                Link = link
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlAsideMenuSection(this HtmlHelper html, string id, string label)
        {
            var ctrl = new CtrlAsideMenuSection
            {
                Id = id,
                Label = label
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlLoginButton(this HtmlHelper html, string id, string viewName, string label, string value, string clickFunction)
        {
            var ctrl = new CtrlLoginButtonModel
            {
                Id = id,
                ViewName = viewName,
                Label = label,
                Value = value,
                ClickFunction = clickFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlAsideButton(this HtmlHelper html, string id, string label, string link, string icon)
        {
            var ctrl = new CtrlAsideButtonModel
            {
                Id = id,
                Label = label,
                Link = link,
                Icon = icon
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction, string colorHeader, string dataId)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction,
                DataId = dataId
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlChart(this HtmlHelper html, string viewName, string id, string title,
            string labels, string chartType, string onLoadFunction)
        {
            var ctrl = new CtrlChartModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Labels = labels,
                ChartType = chartType,
                OnLoadFunction = onLoadFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInput(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName="", string ariaLabel="", string disabled = "")
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                AriaLabel = ariaLabel,
                Disabled = disabled
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputDatePicker(this HtmlHelper html, string id, string label, string placeHolder = "", string columnDataName = "")
        {
            var ctrl = new CtrlInputDatePickerModel
            {
                Id = id,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputLogin(this HtmlHelper html, string id, string type, string placeholder = "", string autocomplete = "on", string validation = "")
        {
            var ctrl = new CtrlInputLoginModel
            {
                Id = id,
                Type = type,
                PlaceHolder = placeholder,
                Autocomplete = autocomplete,
                Validation = validation
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction = "", string buttonType = "primary", string type = "")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType,
                Type = type
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlButtonAction(this HtmlHelper html, string id, string label, string link)
        {
            var ctrl = new CtrlButtonActionModel
            {
                Id = id,
                Label = label,
                Link = link
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlPayPalButton(this HtmlHelper html, string id, string amountValue,
            string divId = "paypal-button-container",
            string transactionCompletedByMessage = "Transaction completed by ",
            string currency = "USD")
        {
            var ctrl = new CtrlPayPalButtonModel {
                Id = id,
                DivId = divId,
                ClientId = "AZspv3QaiTNRMrvWUaucRG3l6gog_Jyue9byrNQrQO_cKf7Qv0d-Dhm4Xi1cOFIjvivWtu44rzaOkOqO",
                AmountValue = amountValue ?? "0.01",
                TransactionCompletedByMessage = transactionCompletedByMessage,
                Currency = currency
            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlTextAreaAutosize(this HtmlHelper html, string id, string label, string labelClass = "",string textAreaClass = "col-lg-4 col-md-9 col-sm-12", string placeHolder = "", string columnDataName = "")
        {
            //id = kt_autosize_2
            var ctrl = new CtrlTextAreaAutosizeModel
            {
                Id = id,
                Label = label,
                LabelClass = labelClass,
                TextAreaClass = textAreaClass,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName

            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputIcon(this HtmlHelper html,
            string id,
            string type,
            string label,
            string placeHolder = "",
            string columnDataName = "",
            string ariaLabel = "",
            string prepend =""
        )
        {
            var ctrl = new CtrlInputIconModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                AriaLabel = ariaLabel,
                Prepend = prepend
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlCurrencyInput(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName = "", string ariaLabel = "", string prepend = ""
)
        {
            var ctrl = new CtrlCurrencyInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder = placeHolder,
                ColumnDataName = columnDataName,
                AriaLabel = ariaLabel,
                Prepend = prepend
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlModalButton(
            this HtmlHelper html,
            string id,
            string label,
            string buttonType = "secondary",
            string type = "button",
            string dataToggle = "",
            string dataTarget = "",
            string dataDismiss = "",
            string ariaLabel = ""
        )
        {
            var ctrl = new CtrlModalButtonModel
            {
                Id = id,
                Label = label,
                ButtonType = buttonType,
                Type = type,
                DataToggle = dataToggle,
                DataTarget = dataTarget,
                DataDismiss = dataDismiss,
                AriaLabel = ariaLabel
            };

            return new HtmlString(ctrl.GetHtml());
        }

        //public static HtmlString CtrlDropDown(this HtmlHelper html, string id, string label, string listId)
        //{
        //    var ctrl = new CtrlDropDownModel
        //    {
        //        Id = id,
        //        Label = label,
        //        ListId = listId
        //    };

        //    return new HtmlString(ctrl.GetHtml());
        //}

        public static HtmlString CtrlButtonNoClass(this HtmlHelper html, string viewName, string id, string label, string onClickFunction = "", string classParam = "", string type = "")
        {
            var ctrl = new CtrlButtonNoClassModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                Class = classParam,
                Type = type
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlInputIconClass(this HtmlHelper html, string viewName, string id, string iconClass = "", string inputClass = "", string inputType = "", string placeholder = "", string name = "", string attributes = "")
        {
            var ctrl = new CtrlInputIconClassModel
            {
                ViewName = viewName,
                Id = id,
                IconClass = iconClass,
                InputClass = inputClass,
                InputType = inputType,
                Placeholder = placeholder,
                Name = name,
                Attributes = attributes
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlPayPalButtonV2(this HtmlHelper html, string id,
            string divId = "paypal-button-container",
            string transactionCompletedByMessage = "Transaction completed by ",
            string currency = "USD")
        {
            var ctrl = new CtrlPayPalButtonV2Model
            {
                Id = id,
                DivId = divId,
                ClientId = "AZspv3QaiTNRMrvWUaucRG3l6gog_Jyue9byrNQrQO_cKf7Qv0d-Dhm4Xi1cOFIjvivWtu44rzaOkOqO",
                TransactionCompletedByMessage = transactionCompletedByMessage,
                Currency = currency
            };
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlPayPalButtonV3(this HtmlHelper html, string id,
            string divId = "paypal-button-container",
            string transactionCompletedByMessage = "Transaction completed by ",
            string currency = "USD")
        {
            var ctrl = new CtrlPayPalButtonV2Model
            {
                Id = id,
                DivId = divId,
                ClientId = "AZspv3QaiTNRMrvWUaucRG3l6gog_Jyue9byrNQrQO_cKf7Qv0d-Dhm4Xi1cOFIjvivWtu44rzaOkOqO",
                TransactionCompletedByMessage = transactionCompletedByMessage,
                Currency = currency
            };
            return new HtmlString(ctrl.GetHtml());
        }
    }   
}