﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bikes.models.Querieis
{
    class AdminAddMake
    {
        public int BikeMakeId { get; set; }
        public int BikeModelId { get; set; }
        public string BikeMake { get; set; }
        public DateTime MakeAddedDate { get; set; }
    }
}