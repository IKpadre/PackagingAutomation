﻿using PackagingAutomation.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Торговая марка")]
    public class Trademark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Продукция")]
        public List<Product> Products { get; set; } = new();

        [NotMapped]
        [DisplayName("Торговые марки")]
        public string? Index { get; set; } = null;
    }
}
