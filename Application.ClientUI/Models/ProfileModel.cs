using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Application.ClientUI.Models
{
    public class ProfileModel
    {
        [Key]
        public int profileID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdentityNumber { get; set; }

        public string Address { get; set; }

        public string CellNo { get; set; }

        public string Date { get; set; }

        public string Clerk { get; set; }

        public string Technician { get; set; }

        public string JobCard { get; set; }
        public string Title { get; set; }

        public string Country { get; set; }
        public string Province { get; set; }
        public string AreaCode { get; set; }

        public string DateOfBirth { get; set; }


        public string SerialNo { get; set; }



        public string Email { get; set; }



        [Display(Name = "Device Name")]
        public string DeviceName
        {
            get; set;
        }
        [Display(Name = "(Hardware/Software)")]
        public string type
        {
            get; set;
        }


        [Display(Name = "Date in")]
        public string datein { get; set; }
        [Display(Name = "Date Out")]
        public string dateout { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        public string Id { get; set; }

   
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string deviceID { get; set; }
      
        public virtual DeviceModel devices { get; set; }
    }
}