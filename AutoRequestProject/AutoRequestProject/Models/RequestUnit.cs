using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AutoRequestProject.Models
{
    public class RequestUnit
    {
        public string title { get; set; }
        // this is miliseconds. 
        public int requestInterval { get; set; }
        public string requestUrl { get; set; }

        private DateTime lastRequestMade { get; set; } = DateTime.MinValue; 
        private bool is_active {
            get
            {
                double t = (DateTime.Now - lastRequestMade).Ticks;
                return (DateTime.Now - lastRequestMade).Ticks < requestInterval; 
            }
        }

        private bool in_work { get; set; } = false; 

        public RequestUnit(string url)
        {
            requestInterval = 100;
            requestUrl = url;
        }
        public RequestUnit(string url, int interval)
        {
            requestInterval = interval;
            requestUrl = url;
        }


        public async Task Start()
        {
            if (is_active || in_work)
                return;

            lastRequestMade = DateTime.Now;
            await MakeRequest(); 
        }

        private async Task MakeRequest()
        {
            in_work = true;
            string htmlCode = ""; 
            // do the work
            using (WebClient client = new WebClient())
            {

                try
                {
                    htmlCode = client.DownloadString(requestUrl);
                }
                catch(Exception e)
                {
                    var test = 1; 
                }

                var test2 = 1; 
            }

            in_work = false;
        }
    }
}
