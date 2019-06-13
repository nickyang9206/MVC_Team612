﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay.Models
{
    public class Search
    {
        public class Category
        {
            public int Category_ID { get; set; }
            public string Category_Name { get; set; }
            public List<string> SubCategory_Name { get; set; }

        }
        public class SubCategory
        {
            public List<string> SubCategory_Name { get; set; }
        }
    }
}