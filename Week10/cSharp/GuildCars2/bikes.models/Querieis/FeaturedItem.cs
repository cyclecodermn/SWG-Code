﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bikes.models.Querieis
{
    public class FeaturedItem
    {
        public int FeatureId { get; set; }

        public int BikeId { get; set; }
        public int BikeYear { get; set; }
        public string BikeMake { get; set; }
        public string BikeModel { get; set; }
        public string BikePictName { get; set; }
    }
}
