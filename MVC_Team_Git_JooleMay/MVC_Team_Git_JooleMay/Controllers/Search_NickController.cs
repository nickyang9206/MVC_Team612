using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public partial class SearchController : Controller
    {
        // GET: Search_Nick
        public ActionResult Search()
        {
            SearchModelS_Model vMSearchModel = new SearchModelS_Model();
            vMSearchModel.CategoriesList = this.GetCategories();
            return View(vMSearchModel);
        }
        [HttpPost]
        public JsonResult Autocomplete(string term, string CategoryID)
        {

            return Json(getSubCategory(term, Convert.ToInt32(CategoryID)), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Search(SearchModelS_Model vMSearchModel)
        {
            int subCategoryID = Convert.ToInt32(vMSearchModel.SubCategoryID);
            Session["sessionSubCategoryID"] = subCategoryID;
            SearchResultS_Model vmSearchResult = new SearchResultS_Model
            {
                ModelTechFilters = _service.GetModelTechFilters(subCategoryID),
                SMProductDetails = _service.GetProductDetails(subCategoryID)
            };
            ProductTypeChkS_Model vMProductTypeChk1 = new ProductTypeChkS_Model("Private", false);
            ProductTypeChkS_Model vMProductTypeChk2 = new ProductTypeChkS_Model("Industrial", false);
            ProductTypeChkS_Model vMProductTypeChk3 = new ProductTypeChkS_Model("Commercial", false);
            List<ProductTypeChkS_Model> vMProductTypeChks = new List<ProductTypeChkS_Model>
            {
                vMProductTypeChk1,
                vMProductTypeChk2,
                vMProductTypeChk3
            };
            vmSearchResult.VMProductTypeChks = vMProductTypeChks;
            vmSearchResult.YearStart = "2010";
            vmSearchResult.YearEnd = DateTime.Now.Year.ToString();
            TempData["VMSearchResults"] = vmSearchResult;
            //return View("SearchResults", vmSearchResult);
            return RedirectToAction("SearchResults", "Search");
        }
        [HttpGet]
        public ActionResult SearchResults()
        {
            SearchResultS_Model vmSearchResult = (SearchResultS_Model)TempData["VMSearchResults"];
            return View(vmSearchResult);
        }
        [HttpPost]

        public ActionResult SearchResults(VMSearchResult vmSearchResult, string submit)
        {

            //switch (submit)
            //{
            //    case "Save":
            //        return PartialView("ProductListPartial", result1);
            //    case "Clear":
            //        return PartialView("ProductListPartial", searchResult);
            //}
            return View();
        }

        public VMSearchResult filterProductList(VMSearchResult vMSearchResult, List<SMProductDetails> sMProductDetails)
        {
            IEnumerable<SMProductDetails> result = sMProductDetails;
            if (vMSearchResult.ModelTechFilters[0] != null)
            {
                decimal min = Convert.ToDecimal(vMSearchResult.ModelTechFilters[0].MinValue);
                decimal max = Convert.ToDecimal(vMSearchResult.ModelTechFilters[0].MaxValue);
                result = sMProductDetails.Where(r => r.AirFlow >= min && r.AirFlow >= max);
            }
            vMSearchResult.SMProductDetails = result.ToList();

            return vMSearchResult;
        }

        public PartialViewResult ProductListPartial(SearchResultS_Model vMSearchResult)
        {
            return PartialView(vMSearchResult.SMProductDetails);
        }

        private List<SelectListItem> GetCategories()
        {
            List<SelectListItem> categoriesList = (from p in _service.getAllCategories().AsEnumerable()
                                                   select new SelectListItem
                                                   {
                                                       Text = p.CategoryName,
                                                       Value = p.CategoryID.ToString()
                                                   }).ToList();
            categoriesList.Insert(0, new SelectListItem { Text = "Category", Value = "0" });
            return categoriesList;
        }



        private List<VMSubCategory> getSubCategory(string searchString, int categoryID)
        {
            List<VMSubCategory> subCateList = new List<VMSubCategory>();

            if (searchString != "")
            {
                var result = _service.GetAllSubCategories().Where(c => c.SubCategoryName.ToUpper().StartsWith(searchString.ToUpper()) && c.CategoryID == categoryID).ToList();
                foreach (var item in result)
                {
                    VMSubCategory subCateItem = new VMSubCategory();
                    subCateItem.SubCategoryID = item.SubCategoryID;
                    subCateItem.SubCategoryName = item.SubCategoryName;
                    subCateList.Add(subCateItem);
                }
            }
            else
            {
                var result = _service.GetAllSubCategories().Where(c => c.CategoryID == categoryID).ToList();
                foreach (var item in result)
                {
                    VMSubCategory subCateItem = new VMSubCategory();
                    subCateItem.SubCategoryID = item.SubCategoryID;
                    subCateItem.SubCategoryName = item.SubCategoryName;
                    subCateList.Add(subCateItem);
                }
            }
            return subCateList;
        }

    }
}