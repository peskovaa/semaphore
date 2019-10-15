using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Semaphore.UI {
    public enum SemaphoreColor { Red, Yellow, Green };

    public class Semaphore : WebControl {
        const string
            SemaphorecssClassName = "semaphore",
            CircleCssClassName = "circle",
            RedCircleCssClassName = "red-circle",
            YellowCircleCssClassName = "yellow-circle",
            GreenCircleCssClassName = "green-circle",
            ActiveCircleCssClassName = "active";

        public Semaphore()
            : base(HtmlTextWriterTag.Div) {
        }

        public SemaphoreColor ActiveColor { get; set; }

        protected WebControl RedCircle { get; private set; }
        protected WebControl YellowCircle { get; private set; }
        protected WebControl GreenCircle { get; private set; }

        protected override void CreateChildControls() {
            if (!string.IsNullOrEmpty(CssClass))
                CssClass += " ";
            CssClass += SemaphorecssClassName;

            RedCircle = CreateCirclye(RedCircleCssClassName);
            Controls.Add(RedCircle);

            YellowCircle = CreateCirclye(YellowCircleCssClassName);
            Controls.Add(YellowCircle);

            GreenCircle = CreateCirclye(GreenCircleCssClassName);
            Controls.Add(GreenCircle);

            SetActiveColorToContol();
        }

        protected void SetActiveColorToContol() {
            var activeCircleControl = GetActiveCircleControl();
            activeCircleControl.CssClass += $" {ActiveCircleCssClassName}";
        }

        WebControl GetActiveCircleControl() {
            switch (ActiveColor) {
                case SemaphoreColor.Red:
                    return RedCircle;
                case SemaphoreColor.Yellow:
                    return YellowCircle;
                case SemaphoreColor.Green:
                    return GreenCircle;
            }
            throw new NotImplementedException();
        }

        WebControl CreateCirclye(string coloredCircleCssClassName) {
            var circle = new WebControl(HtmlTextWriterTag.Div);
            circle.CssClass = $"{CircleCssClassName} {coloredCircleCssClassName}";
            return circle;
        }
    }
}