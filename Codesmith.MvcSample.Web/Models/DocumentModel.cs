using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Codesmith.MvcSample.Web.Models
{
    public class DocumentModel
    {
        [Required]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}