using AutoRequestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRequestProject.Service
{
    public class AutoRequestService
    {
        private ICollection<RequestUnit> requestUnits = new List<RequestUnit>(); 
        private bool in_active_mode = false; 


        // singleton
        private AutoRequestService()
        {

        }
        private static AutoRequestService service { get; set; }
        public static AutoRequestService GetService()
        {
            if(service == null)
                service = new AutoRequestService();

            return service; 
        }

        // public methods
        public void AddNew(RequestUnit unit)
        {
            requestUnits.Add(unit);
        }

        public void Reset()
        {
            requestUnits.Clear(); 
        }

        public void Stop()
        {
            in_active_mode = false; 
        }

        public void StartService()
        {
            Test(); 
            in_active_mode = true;

            while (in_active_mode)
            {
                foreach (RequestUnit unit in requestUnits)
                {
                    unit.Start(); 
                }
            }
        }

        public void Test()
        {
            AddNew(new RequestUnit("https://yiju.ca/page/49788/2020%e5%b9%b4%e5%8a%a0%e6%8b%bf%e5%a4%a7%e7%9c%81%e6%8f%90%e5%90%8d%e7%a7%bb%e6%b0%91%e5%a2%9e%e5%8a%a011-percent.aspx?sid=188888", 1000)); 
        }
    }
}
