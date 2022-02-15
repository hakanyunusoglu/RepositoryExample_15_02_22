using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryExample_15_02_22.Models
{
    public class ProductsModel
    {
        public List<Products> pList { get; set; }
        public Products Products { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}