using System;
using System.Collections.Generic;
using System.Text;

namespace Codesmith.MvcSample.DataAccess.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}