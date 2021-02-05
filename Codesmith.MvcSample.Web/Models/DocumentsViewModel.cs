using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codesmith.MvcSample.Web.Models
{
    public class DocumentsViewModel : BasePageModel
    {
        public List<DocumentModel> Documents { get; set; }
    }
}