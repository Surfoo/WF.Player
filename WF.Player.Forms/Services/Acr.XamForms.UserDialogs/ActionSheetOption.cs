﻿using System;

namespace Acr.XamForms.UserDialogs {

    public class ActionSheetOption {

        public string Text { get; set; }
        public Action Action { get; set; }

        public ActionSheetOption(string text, Action action = null) {
            this.Text = text;
            this.Action = (action ?? (() => {}));
        }
    }
}
