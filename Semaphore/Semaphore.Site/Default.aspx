<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Semaphore.Site.Default" ViewStateMode="Disabled"%>

<%@ Register TagPrefix="ap" Namespace="Semaphore.UI" Assembly="Semaphore.UI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .semaphore {
            width: 100px;
            height: 300px;
            background: grey;
            position: relative;    
        }
        .semaphore .circle {
            width: 100px;
            height: 100px;
            border-radius: 50px;
            position: relative;
            background: rgb(175, 175, 175);
        }
        .semaphore .red-circle.active {
            background: red;
        }
        .semaphore .yellow-circle.active {
            background: yellow;
        }
        .semaphore .green-circle.active {
            background: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ap:Semaphore ID="Semaphore" ActiveColor="Green"  runat="server" /> 
        <br/>
        <asp:Button ID="ReloadPageButton"  runat="server" Text="Reload Page" />
        <input type="button"  onclick="semaphore._resetState()" value="Switch OFF" runat="server"/>
    </form>
    <script>
        const
            ActiveCircleClassName = "active",
            FieldId = "State",
            CircleClassName = "circle",
            RedColor = "red",
            YellowColor = "yellow",
            GreenColor = "green";

        const CssColorPattern = new RegExp("(\\w+)\\-circle");

        var semaphore = {
            init: function () {
                const mainElement = this._getMainElement();
                const circleElements = mainElement.getElementsByClassName(CircleClassName);

                const color = this._getColorFromHiddenField();
                this.setActiveColor(color);

                for (let i = 0; i < circleElements.length; i++) {
                    circleElements[i].onclick = this._onCircleClick.bind(this);
                }
            },
            _onCircleClick: function (event) {
                const circleElement = event.target;
                if (!circleElement)
                    return;

                const matches = circleElement.className.match(CssColorPattern);
                const color = (matches.length >= 2) ? matches[1] : "";
                this.setActiveColor(color);
                this._setColorToHiddenField(color);
            },
            setActiveColor: function (color) {
                if (!color) return;

                const circleElement = this._getCircleElement(color);
                this._resetState();
                this._setActiveElementState(circleElement);
            },
            _setColorToHiddenField: function (color) {
                let hiddenFieldId = this._getHiddenFieldId(FieldId);
                const hiddenField = document.getElementById(hiddenFieldId);
                hiddenField.value = color;
            },
            _getColorFromHiddenField: function () {
                let hiddenFieldId = this._getHiddenFieldId(FieldId);
                const hiddenField = document.getElementById(hiddenFieldId);
                return hiddenField.value;
            },
            _getHiddenFieldId: function (FieldId) {
                return this._getMainElement().id + "_" + FieldId;
            },
            _setActiveElementState: function (circleElement) {
                if (!circleElement || circleElement.className.indexOf(ActiveCircleClassName) > -1)
                    return;
                circleElement.className += " " + ActiveCircleClassName;
            },
            _getMainElement: function () {
                return document.getElementById("Semaphore");
            },
            _getCircleElement: function (color) {
                const maintElement = this._getMainElement();
                for (var i = 0; i < maintElement.children.length; i++) {
                    const circleElement = maintElement.children[i];
                    if (circleElement.className.indexOf(color) > -1)
                        return circleElement;
                }
                return null;
            },
            _resetState: function () {
                const circleElements = document.getElementsByClassName(CircleClassName);
                for (let i = 0; i < circleElements.length; i++) {
                    circleElements[i].className = circleElements[i].className.replace(" " + ActiveCircleClassName, "") ;
                }
            },
        };

        window.onload = function () {
            semaphore.init();
        };

</script>
</body>
</html>
