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
            in_active_mode = true;

            while (in_active_mode)
            {
                foreach (RequestUnit unit in requestUnits)
                {
                    unit.Start(); 
                }
            }
        }


    }
}
