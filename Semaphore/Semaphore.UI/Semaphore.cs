using System.Web.UI;
using System.Web.UI.WebControls;

namespace Semaphore.UI {
    public class Semaphore : WebControl {

        protected override void CreateChildControls() {
            var literal = new LiteralControl("Hello from Semaphore!!!");
            Controls.Add(literal);
        }
    }
}