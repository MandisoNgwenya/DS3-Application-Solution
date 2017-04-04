using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.ClientUI.Models
{
    public class DatePick
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input name")]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]

        public Nullable<System.DateTime> DOB { get; set; }
    }
}