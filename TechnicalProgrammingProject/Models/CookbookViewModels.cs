using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalProgrammingProject.Models
{
    public class CookbookViewModel
    {
        public CookbookViewModel()
        {
            Recipes = new List<Recipe>();
        }
        public string ID { get; set; }
        public string DisplayName { get; set; }
        public virtual List<Recipe> Recipes { get; set; }
    }
}