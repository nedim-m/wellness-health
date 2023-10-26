﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Treatment
{
    public class Treatment
    {
        public int Id { get; set; }

        public string TreatmentType { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }

        public float Price { get; set; }

        public byte[] Picture { get; set; } = null!;
    }
}
