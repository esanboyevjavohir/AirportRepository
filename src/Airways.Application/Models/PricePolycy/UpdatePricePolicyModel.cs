﻿using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.PricePolycy
{
    public class UpdatePricePolicyModel
    {
        
        public decimal DiscountPercentage { get; set; }
        public string Conditions { get; set; }
    }
    public class UpdatePricePolicyResponceModel : BaseResponceModel { }
}
