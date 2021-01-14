﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalEmploymentTest.Models
{
    public class ModelImageFavorite
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public bool chekedFavorite { get; set; }
    }
}