using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<Videos> GetListYoutube(string keyword)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAV7dZdpjsqH9K2IkJ0tlqHWklDay0qMW4",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified query term.
            SearchListResponse searchListResponse = searchListRequest.Execute();

            IList<SearchResult> searchResults = searchListResponse.Items;
            List<Videos> listvideos = new List<Videos>();

            foreach (var item in searchResults)
            {
                listvideos.Add(new Videos { ID = item.Id.VideoId, tittle = item.Snippet.Title });
            }
            return listvideos;
        }
    }
}
