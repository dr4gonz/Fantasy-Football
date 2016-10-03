using Fantasy_Football.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football.Models
{
    [Table("NflGames")]
    public class NflGame
    {
        [Key]
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeScore { get; set; }
        public string AwayScore { get; set; }
        public string HomeScoreQuarter1 { get; set; }
        public string HomeScoreQuarter2 { get; set; }
        public string HomeScoreQuarter3 { get; set; }
        public string HomeScoreQuarter4 { get; set; }
        public string HomeScoreOvertime { get; set; }
        public string AwayScoreQuarter1 { get; set; }
        public string AwayScoreQuarter2 { get; set; }
        public string AwayScoreQuarter3 { get; set; }
        public string AwayScoreQuarter4 { get; set; }
        public string AwayScoreOvertime { get; set; }
        public string StadiumName { get; set; }
        public string Week { get; set; }
        public NflGame () { }
        public static List<NflGame> GetGames()
        {
            var client = new RestClient("https://api.fantasydata.net/v3/nfl/scores/JSON/Scores");
            var request = new RestRequest("2016REG", Method.GET);
            client.AddDefaultHeader(EnvironmentVariables.Key, EnvironmentVariables.Token);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray responseJson = JArray.Parse(response.Content);
            List<NflGame> games = new List<NflGame>();
            foreach(var jGame in responseJson)
            {
                JObject game = jGame as JObject;
                NflGame newGame = game.ToObject<NflGame>();
                games.Add(newGame);
            }
            return games;
        }

        private static Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
