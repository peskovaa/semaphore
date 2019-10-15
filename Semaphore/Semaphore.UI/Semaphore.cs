using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Semaphore.UI {
    public class Semaphore : WebControl {
        const string
            SemaphorecssClassName = "semaphore",
            CircleCssClassName = "circle",
            RedCircleCssClassName = "red-circle",
            YellowCircleCssClassName = "yellow-circle",
            GreenCircleCssClassName = "green-circle";

        public Semaphore()
            : base(HtmlTextWriterTag.Div) {
        }

        protected override void CreateChildControls() {
            if (!string.IsNullOrEmpty(CssClass))
                CssClass += " ";
            CssClass += SemaphorecssClassName;

            var redCircle = CreateCirclye(RedCircleCssClassName);
            Controls.Add(redCircle);

            var yellowCircle = CreateCirclye(YellowCircleCssClassName);
            Controls.Add(yellowCircle);

            var greenCircle = CreateCirclye(GreenCircleCssClassName);
            Controls.Add(greenCircle);
        }

        WebControl CreateCirclye(string coloredCircleCssClassName) {
            var circle = new WebControl(HtmlTextWriterTag.Div);
            circle.CssClass = $"{CircleCssClassName} {coloredCircleCssClassName}";
            return circle;
        }
    }
}