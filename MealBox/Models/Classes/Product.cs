﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealBox.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]

        public string skt { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string? ProductDescription { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string? Brand { get; set; }

        public int? Stock { get; set; }
        public double Price { get; set; }
        public bool? Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string? Image { get; set; }

        
       
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string? Province { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string? Town { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string? District { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int UserId { get; set; } // Foreign Key
        public User User { get; set; }    // Navigation Property
    

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public bool? Solded { get; set; }

       
        public double? Latitude { get; set; } // Enlem

        public double? Longitude { get; set; } // Boylam

        public double? Distance { get; set; }

    }
}
