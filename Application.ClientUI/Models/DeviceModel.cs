using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Application.ClientUI.Models
{
    public class DeviceModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Serial Number")]
        public string serialNo { get; set; }
        [Display(Name = "Technician")]
        public string technician
        {
            get; set;
        }
        [Display(Name = "Identity Number")]
        public string customerIdNumber
        {
            get; set;
        }
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
      


    }
}