using System.Net;
using System.Reflection;

namespace StoreMembershipApi.Models
{
    public class StoreResponseContent
    {
        public string Version { get; set; }
        public int Status { get; set; }
        public string UserMessage { get; set; }

		public StoreResponseContent()
		{ }

		public StoreResponseContent(string message, HttpStatusCode status)
        {
            this.UserMessage = message;
            this.Status = (int)status;
            this.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}