<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Player.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Player</title>
</head>
    <style>
        body{
            background-color:red;
        }
    </style>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="FetchIdsFromDBo" runat="server" BackColor="Turquoise" Text="Don't click me" BorderColor="Yellow" OnClick="FetchIdsFromDBo_click" Width="226px" Height="49px"></asp:Button><br />
        <input type="hidden" runat="server" id="ListOfIds" value="" />

        <div id="player" style="position: absolute; top: 100px; left: 100px;"></div>
        <div id="info">loading...</div>

        <script src="http://www.youtube.com/player_api"></script>

        <script>

            debugger;

            var temp = document.getElementById('ListOfIds').value;
            var string;
            string = temp;
            var array = JSON.parse(string);

            var NumberOfSongs = array.length;

            if (document.getElementById('ListOfIds').value != '')
            {
                document.getElementById('ListOfIds').value = '';
            }

            function onYouTubePlayerAPIReady(){

                var NumbersOfEnds = 0;

                var player = new YT.Player('player',
                    {
                        loop: true,
                        playerVars: { 'autoplay': 1, 'controls': 1, 'playlist': [array], },
                        events:
                        {
                            onReady: function ()
                            {
                                info.innerHTML = 'video is loaded';
                            },
                            onStateChange: function (event)
                            {
                                if (event.data === 1)
                                {
                                    info.innerHTML = 'video started playing';
                                }
                                if (event.data == YT.PlayerState.ENDED)
                                {
                                    NumbersOfEnds += 1;
                                    if (NumbersOfEnds == NumberOfSongs)
                                    {

                                        document.getElementById("FetchIdsFromDBo").click();
                                    }
                                }
                            },

                        },
                    })
            }
        </script>
    </form>
</body>
</html>
