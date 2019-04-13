using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using bikes.models.Tables;

namespace bikes.models.VMs
{
    public class BikeAddViewModel: IValidatableObject
    {
        public IEnumerable<SelectListItem> BikeMakes { get; set; }
        public IEnumerable<SelectListItem> BikeModels { get; set; }

        public List<SelectListItem> BikeYearItems { get; set; }
        public IEnumerable<SelectListItem> BikeYears { get; set; }

        public List<SelectListItem> BikeGearItems { get; set; }
        public IEnumerable<SelectListItem> BikeGears { get; set; }
        
        public List<SelectListItem> FrameColorItems { get; set; }
        public string FrameColor { get; set; }
        public IEnumerable<SelectListItem> TrimColor { get; set; }

        public List<SelectListItem> FrameItems { get; set; }
        public string FrameType { get; set; }


        public List<SelectListItem> ConditionItems { get; set; }
        public string Condition { get; set; }


        public BikeTable Bike { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
