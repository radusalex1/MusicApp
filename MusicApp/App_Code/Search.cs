using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for Search
/// </summary>
public class Search
{
    public string Title { get; set; }

    public Search(string inputSong)
    {
        try
        {
            Title = inputSong;
            new Search(inputSong).Run().Wait();
            
        }
        catch (AggregateException ex)
        {
            foreach (var e in ex.InnerExceptions)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

    }

    public async Task Run()
    {
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyBVvucgojORJb8jPoygqAit9tIVMGNPerg",
            ApplicationName = this.GetType().ToString()
        });

        var searchListRequest = youtubeService.Search.List("snippet");
        Console.WriteLine("Give the name of a song:");
        string temp = Title;

        searchListRequest.Q = temp; // Replace with your search term.
        searchListRequest.MaxResults = 1;

        // Call the search.list method to retrieve results matching the specified query term.
        var searchListResponse = await searchListRequest.ExecuteAsync();

        List<string> videos = new List<string>();
        List<string> channels = new List<string>();
        List<string> playlists = new List<string>();

        // Add each result to the appropriate list, and then display the lists of
        // matching videos, channels, and playlists.
        foreach (var searchResult in searchListResponse.Items)
        {
            switch (searchResult.Id.Kind)
            {
                case "youtube#video":
                    videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                    break;

                case "youtube#channel":
                    channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                    break;

                case "youtube#playlist":
                    playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                    break;
            }
        }

        Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
        Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
        Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));

    }

}