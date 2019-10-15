<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Semaphore.Site.Default" %>

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
        <ap:Semaphore ID="Semaphore" ActiveColor="Red" runat="server" />
    </form>
</body>
</html>
