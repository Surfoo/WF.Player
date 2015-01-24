using System;
using Vernacular;


namespace Acr.XamForms.UserDialogs {
    
    public class AlertConfig {

        public string OkText { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public Action OnOk { get; set; }


        public AlertConfig() {
			this.OkText = Catalog.GetString("Ok");
        }


        //public static AlertConfig Create(string message) {
        //    return new AlertConfig {
        //        Message = message
        //    };
        //}

        public AlertConfig SetOkText(string text) {
            this.OkText = text;
            return this;
        }


        public AlertConfig SetTitle(string title) {
            this.Title = title;
            return this;
        }


        public AlertConfig SetMessage(string message) {
            this.Message = message;
            return this;
        }


        public AlertConfig SetCallback(Action onOk) {
            this.OnOk = onOk;
            return this;
        }
    }
}
