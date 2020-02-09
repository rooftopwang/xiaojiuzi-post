using System;
using System.Collections.Generic;
using System.Linq;
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
                return (new DateTime() - lastRequestMade).Milliseconds < requestInterval; 
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

            lastRequestMade = new DateTime();
            await MakeRequest(); 
        }

        private async Task MakeRequest()
        {
            in_work = true;

            // do the work

            in_work = false;
        }
    }
}
