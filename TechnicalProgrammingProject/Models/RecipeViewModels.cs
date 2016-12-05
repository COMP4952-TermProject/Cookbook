using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TechnicalProgrammingProject.Attributes;

namespace TechnicalProgrammingProject.Models
{
    public class CreateRecipeViewModel
    {
        public CreateRecipeViewModel()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Cook Time")]
        [Range(0, 2880)]
        public int CookTime { get; set; }
        [Required]
        [Range(0,100)]
        public int Servings { get; set; }

        [Image]
        public HttpPostedFileBase Image { get; set; }
        public byte[] recipePicture { get; set; }

        [Required]
        public string Directions { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }

    /// <summary>
    /// Model used to display information available for editting.
    /// </summary>
    public class EditRecipeViewModel
    {
        /// <summary>
        /// Initialize the Ingredients for the recipe.
        /// </summary>
        public EditRecipeViewModel()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        /// <summary>
        /// ID of the recipe to edit.
        /// </summary>
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// Name of the recipe.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Description of the recipe.
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Time needed to cook the recipe.
        /// </summary>
        [Required]
        [DisplayName("Cook Time")]
        [Range(0, 2880)]
        public int CookTime { get; set; }

        /// <summary>
        /// Number of servings the recipe provides.
        /// </summary>
        [Required]
        [Range(0, 100)]
        public int Servings { get; set; }

        /// <summary>
        /// Image upload of the recipe.
        /// </summary>
        [Image]
        public HttpPostedFileBase RecipePicture { get; set; }

        /// <summary>
        /// Actual Image of the Recipe.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Directions to cook the recipe.
        /// </summary>
        [Required]
        public string Directions { get; set; }

        /// <summary>
        /// Ingredients required to make the recipe.
        /// </summary>
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Tags used by searching.
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
    }

    public class UploadsViewModel
    {
        public UploadsViewModel()
        {
            Recipes = new HashSet<Recipe>();
        }
        public string ID { get; set; }
        public string UploaderName { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }

    public class UploadedRecipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public DateTime? DateUploaded { get; set; }
        public string Status { get; set; }
        [DisplayName("Delete")]
        public bool isDelete { get; set; }
    }
    public class DeleteRecipeViewModel
    {
        public DeleteRecipeViewModel()
        {
            UploadedRecipes = new List<UploadedRecipe>();
        }
        public virtual List<UploadedRecipe> UploadedRecipes { get; set; }
    }
}