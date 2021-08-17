using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    string ConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

    public void FetchIdsFromDboHelper(List<string> list )
    {
        var con = new SqlConnection(ConnectionString);
        con.Open();
        
            var cmd = new SqlCommand("select top(10) YoutubeId from SongsMainTable where SentToPlayPart = 0;", con);
            SqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                list.Add(result[0].ToString());
            }
          
        con.Close();
    }

    public void FetchIdsFromDBo_click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();

        FetchIdsFromDboHelper(list);
        string serializedList = (new JavaScriptSerializer()).Serialize(list);
        ListOfIds.Value += serializedList;

        updateSongs();
    }

    public void updateSongs()
    {
        var con = new SqlConnection(ConnectionString);
        con.Open();
        var cmd_update = new SqlCommand("update SongsMainTable set SentToPlayPart = 1  where SentToPlayPart=0",con);
        cmd_update.ExecuteNonQuery();
        con.Close();
    }

}
