<%@ Page CodeBehind="~/ServerSearch.aspx.cs" Async="true" Language="C#" AutoEventWireup="true" CodeFile="ServerSearch.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Welcome to party</title>
</head>
    <style>
        body{
            background-color:chocolate;
        }
    </style>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="inputSong" placeholder="Enter song name here..." runat="server"></asp:TextBox>Any search costs 100 units.... use it wisely:))----10,000 units per day----<br />

        <br />
       
        <script src="http://www.youtube.com/player_api"></script>
    <script>
        if (document.getElementById("inputSong").value != "") {
            document.getElementById("inputSong").value = '';
        }
    </script>

        <asp:Button ID="btn_input" runat="server" OnClick="btn_input_ClickAsync" Text="Add to queue..." Width="176px" BorderColor="Green" ForeColor="blue" Height="58px" />
        <p>
            &nbsp;</p>
    </form>
    </body>
</html>
