﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaApi.Models.Dto
{
    public class VillaNumberCreateDTO
    {
        [Required]
        public required int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public required string SpecialDetails { get; set; }
    }
}
