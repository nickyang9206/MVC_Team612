using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay_Service.Models
{
    public class ProductTypeChkS_Model
    {
        public string ProductTypeName { get; set; }
        public bool IsProductTypeChecked { get; set; }
        public ProductTypeChkS_Model(string _productTypeName,bool _checkedtype =false)
        {
            ProductTypeName = _productTypeName;
            IsProductTypeChecked = _checkedtype;
        }
        public ProductTypeChkS_Model()
        {
        }
    }
}