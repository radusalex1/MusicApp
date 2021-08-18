<%@ Page CodeBehind="~/ServerSearch.aspx.cs" Async="true" Language="C#" AutoEventWireup="true" CodeFile="ServerSearch.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Welcome to party</title>

</head>

    <style>
        body{
            margin-top:2cm;
            text-align: center;
            background-color:chocolate;
        }
        form{
            
            display: inline-block;

        }
    </style>

    

<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="inputSong" placeholder="Enter song name here..." runat="server"></asp:TextBox><br />
        <br/>

        <script>
            if (document.getElementById("inputSong").value != "")
            {
                document.getElementById("inputSong").value = '';
            }
        </script>
        <script src="http://www.youtube.com/player_api"></script>

        <asp:Button ID="btn_input" runat="server" OnClick="btn_input_ClickAsync" Text="Add to queue..." Width="176px" BorderColor="brown" BackColor="Brown"  ForeColor="Black" Height="58px" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
