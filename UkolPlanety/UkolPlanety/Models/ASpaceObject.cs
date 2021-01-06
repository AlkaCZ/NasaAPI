using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UkolPlanety.Models
{
    public class ASpaceObject
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public bool IsHazerdious { get; set; }
        public double Speed { get; set; }

        public ASpaceObject()
        {

        }
    }
}
