﻿using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Classs
{
    public class ClassResponceModel : BaseResponceModel
    {
        public ClassType className { get; set; }
        public string description { get; set; }
    }
}
