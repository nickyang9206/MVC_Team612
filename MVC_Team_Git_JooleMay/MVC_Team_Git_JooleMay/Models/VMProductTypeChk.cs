using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMProductTypeChk
    {
        public string ProductTypeName { get; set; }
        public bool IsProductTypeChecked { get; set; }
        public VMProductTypeChk(string _productTypeName,bool _checkedtype =false)
        {
            ProductTypeName = _productTypeName;
            IsProductTypeChecked = _checkedtype;
        }
        public VMProductTypeChk()
        {
        }
    }
}