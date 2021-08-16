using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    string ConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    public void btn_input_ClickAsync(Object sender, EventArgs e)
    {
        string title = inputSong.Text;
        Search(title);
    }

    public void Search(string Title)
    {
        var ApiKey = ConfigurationManager.AppSettings["YtApiKey"];
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = ApiKey,
            ApplicationName = this.GetType().ToString()
        }); ;

        var searchListRequest = youtubeService.Search.List("snippet");
        
        string temp = Title;

        searchListRequest.Q = temp; // Replace with your search term.
        searchListRequest.MaxResults = 1;

        // Call the search.list method to retrieve results matching the specified query term.
        var searchListResponse = searchListRequest.Execute();

        List<string> videos = new List<string>();

        // Add each result to the appropriate list, and then display the lists of
        // matching videos, channels, and playlists.
        foreach (var searchResult in searchListResponse.Items)
        {
            switch (searchResult.Id.Kind)
            {
                case "youtube#video":
                    videos.Add(searchResult.Id.VideoId);
                    string id = videos[0];
                    InsertIdToDbo(temp, id);
                    break;
            }
        }
    }

    public void InsertIdToDbo(string title, string id)
    {
        var con = new SqlConnection(ConnectionString); 
        con.Open();
        var insert_cmd = new SqlCommand("insert into SongsMainTable (Name,YoutubeId,SentToPlayPart) values (@name,@idStatus,@idTrimis)", con);
        insert_cmd.Parameters.AddWithValue("@name", title);
        insert_cmd.Parameters.AddWithValue("@idStatus", id);
        insert_cmd.Parameters.AddWithValue("@idTrimis", 0);
        insert_cmd.ExecuteNonQuery();
        con.Close();
    }

}


