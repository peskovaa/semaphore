using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Semaphore.UI {

    public enum SemaphoreColor { Red, Yellow, Green };

    public class Semaphore : WebControl, IPostBackDataHandler, INamingContainer {
        const string
            SemaphorecssClassName = "semaphore",
            CircleCssClassName = "circle",
            RedCircleCssClassName = "red-circle",
            YellowCircleCssClassName = "yellow-circle",
            GreenCircleCssClassName = "green-circle";

        const string StateInputId = "State";

        public Semaphore()
            : base(HtmlTextWriterTag.Div) {
        }

        SemaphoreColor activeColor;
        public SemaphoreColor ActiveColor {
            get { return activeColor; }
            set {
                if (activeColor == value)
                    return;
                ChildControlsCreated = false;
                activeColor = value;
            }
        }

        protected WebControl RedCircle { get; private set; }
        protected WebControl YellowCircle { get; private set; }
        protected WebControl GreenCircle { get; private set; }
        protected HtmlInputHidden HiddenField { get; private set; }

        protected override void CreateChildControls(){
            CssClass = SemaphorecssClassName;

            RedCircle = CreateCirclye(RedCircleCssClassName);
            Controls.Add(RedCircle);

            YellowCircle = CreateCirclye(YellowCircleCssClassName);
            Controls.Add(YellowCircle);

            GreenCircle = CreateCirclye(GreenCircleCssClassName);
            Controls.Add(GreenCircle);

            HiddenField = new HtmlInputHidden{
                ID = StateInputId,
                Value = (activeColor.ToString("g")).ToLower()
            };
            Controls.Add(HiddenField);
         }

        WebControl CreateCirclye(string coloredCircleCssClassName) {
            var circle = new WebControl(HtmlTextWriterTag.Div);
            circle.CssClass = $"{CircleCssClassName} {coloredCircleCssClassName}";
            return circle;
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            Page.RegisterRequiresPostBack(this);
        }

        public bool LoadPostData(string postDataKey, NameValueCollection postCollection) {
            var stateKey = ClientID + "$" + StateInputId;
            var rawState = postCollection[stateKey];
            if (!string.IsNullOrEmpty(rawState)) {
                SemaphoreColor newSemaphoreColor;
                if (Enum.TryParse(rawState, true, out newSemaphoreColor))
                    this.ActiveColor = newSemaphoreColor;
            }
            return true;
        }

        public void RaisePostDataChangedEvent() {
            
        }
    }
}