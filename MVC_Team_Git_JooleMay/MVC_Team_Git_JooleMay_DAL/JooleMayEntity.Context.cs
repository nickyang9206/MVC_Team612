﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Team_Git_JooleMay_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JooleMayEntities : DbContext
    {
        public JooleMayEntities()
            : base("name=JooleMayEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblManufacture> tblManufactures { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductCategory> tblProductCategories { get; set; }
        public virtual DbSet<tblProductProperty> tblProductProperties { get; set; }
        public virtual DbSet<tblProductSubCategory> tblProductSubCategories { get; set; }
        public virtual DbSet<tblProductTypeDetail> tblProductTypeDetails { get; set; }
        public virtual DbSet<tblProject> tblProjects { get; set; }
        public virtual DbSet<tblSery> tblSeries { get; set; }
        public virtual DbSet<tblTechnicalSpecification> tblTechnicalSpecifications { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblTechSpecFilter> tblTechSpecFilters { get; set; }
        public virtual DbSet<tblProject2Product> tblProject2Product { get; set; }
    
        public virtual int spGetProductDetails(Nullable<int> productID, Nullable<int> subCategoryID, Nullable<decimal> max_AirFlow, Nullable<decimal> min_AirFlow, Nullable<decimal> max_PowerMin, Nullable<decimal> min_PowerMin, Nullable<decimal> max_PowerMax, Nullable<decimal> min_PowerMax, Nullable<decimal> max_VACMin, Nullable<decimal> min_VACMin, Nullable<decimal> max_VACMAX, Nullable<decimal> min_VACMAX, Nullable<int> max_FanSpeedMin, Nullable<int> min_FanSpeedMin, Nullable<int> max_FanSpeedMax, Nullable<int> min_FanSpeedMax, Nullable<int> max_NumberofFanSpeed, Nullable<int> min_NumberofFanSpeed, Nullable<int> max_SoundAtMaxSpeed, Nullable<int> min_SoundAtMaxSpeed, Nullable<decimal> max_FanSweepDiameter, Nullable<decimal> min_FanSweepDiameter, Nullable<decimal> max_HeightMin, Nullable<decimal> min_HeightMin, Nullable<decimal> max_HeightMax, Nullable<decimal> min_HeightMax, Nullable<decimal> max_Weight, Nullable<decimal> min_Weight)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var subCategoryIDParameter = subCategoryID.HasValue ?
                new ObjectParameter("SubCategoryID", subCategoryID) :
                new ObjectParameter("SubCategoryID", typeof(int));
    
            var max_AirFlowParameter = max_AirFlow.HasValue ?
                new ObjectParameter("Max_AirFlow", max_AirFlow) :
                new ObjectParameter("Max_AirFlow", typeof(decimal));
    
            var min_AirFlowParameter = min_AirFlow.HasValue ?
                new ObjectParameter("Min_AirFlow", min_AirFlow) :
                new ObjectParameter("Min_AirFlow", typeof(decimal));
    
            var max_PowerMinParameter = max_PowerMin.HasValue ?
                new ObjectParameter("Max_PowerMin", max_PowerMin) :
                new ObjectParameter("Max_PowerMin", typeof(decimal));
    
            var min_PowerMinParameter = min_PowerMin.HasValue ?
                new ObjectParameter("Min_PowerMin", min_PowerMin) :
                new ObjectParameter("Min_PowerMin", typeof(decimal));
    
            var max_PowerMaxParameter = max_PowerMax.HasValue ?
                new ObjectParameter("Max_PowerMax", max_PowerMax) :
                new ObjectParameter("Max_PowerMax", typeof(decimal));
    
            var min_PowerMaxParameter = min_PowerMax.HasValue ?
                new ObjectParameter("Min_PowerMax", min_PowerMax) :
                new ObjectParameter("Min_PowerMax", typeof(decimal));
    
            var max_VACMinParameter = max_VACMin.HasValue ?
                new ObjectParameter("Max_VACMin", max_VACMin) :
                new ObjectParameter("Max_VACMin", typeof(decimal));
    
            var min_VACMinParameter = min_VACMin.HasValue ?
                new ObjectParameter("Min_VACMin", min_VACMin) :
                new ObjectParameter("Min_VACMin", typeof(decimal));
    
            var max_VACMAXParameter = max_VACMAX.HasValue ?
                new ObjectParameter("Max_VACMAX", max_VACMAX) :
                new ObjectParameter("Max_VACMAX", typeof(decimal));
    
            var min_VACMAXParameter = min_VACMAX.HasValue ?
                new ObjectParameter("Min_VACMAX", min_VACMAX) :
                new ObjectParameter("Min_VACMAX", typeof(decimal));
    
            var max_FanSpeedMinParameter = max_FanSpeedMin.HasValue ?
                new ObjectParameter("Max_FanSpeedMin", max_FanSpeedMin) :
                new ObjectParameter("Max_FanSpeedMin", typeof(int));
    
            var min_FanSpeedMinParameter = min_FanSpeedMin.HasValue ?
                new ObjectParameter("Min_FanSpeedMin", min_FanSpeedMin) :
                new ObjectParameter("Min_FanSpeedMin", typeof(int));
    
            var max_FanSpeedMaxParameter = max_FanSpeedMax.HasValue ?
                new ObjectParameter("Max_FanSpeedMax", max_FanSpeedMax) :
                new ObjectParameter("Max_FanSpeedMax", typeof(int));
    
            var min_FanSpeedMaxParameter = min_FanSpeedMax.HasValue ?
                new ObjectParameter("Min_FanSpeedMax", min_FanSpeedMax) :
                new ObjectParameter("Min_FanSpeedMax", typeof(int));
    
            var max_NumberofFanSpeedParameter = max_NumberofFanSpeed.HasValue ?
                new ObjectParameter("Max_NumberofFanSpeed", max_NumberofFanSpeed) :
                new ObjectParameter("Max_NumberofFanSpeed", typeof(int));
    
            var min_NumberofFanSpeedParameter = min_NumberofFanSpeed.HasValue ?
                new ObjectParameter("Min_NumberofFanSpeed", min_NumberofFanSpeed) :
                new ObjectParameter("Min_NumberofFanSpeed", typeof(int));
    
            var max_SoundAtMaxSpeedParameter = max_SoundAtMaxSpeed.HasValue ?
                new ObjectParameter("Max_SoundAtMaxSpeed", max_SoundAtMaxSpeed) :
                new ObjectParameter("Max_SoundAtMaxSpeed", typeof(int));
    
            var min_SoundAtMaxSpeedParameter = min_SoundAtMaxSpeed.HasValue ?
                new ObjectParameter("Min_SoundAtMaxSpeed", min_SoundAtMaxSpeed) :
                new ObjectParameter("Min_SoundAtMaxSpeed", typeof(int));
    
            var max_FanSweepDiameterParameter = max_FanSweepDiameter.HasValue ?
                new ObjectParameter("Max_FanSweepDiameter", max_FanSweepDiameter) :
                new ObjectParameter("Max_FanSweepDiameter", typeof(decimal));
    
            var min_FanSweepDiameterParameter = min_FanSweepDiameter.HasValue ?
                new ObjectParameter("Min_FanSweepDiameter", min_FanSweepDiameter) :
                new ObjectParameter("Min_FanSweepDiameter", typeof(decimal));
    
            var max_HeightMinParameter = max_HeightMin.HasValue ?
                new ObjectParameter("Max_HeightMin", max_HeightMin) :
                new ObjectParameter("Max_HeightMin", typeof(decimal));
    
            var min_HeightMinParameter = min_HeightMin.HasValue ?
                new ObjectParameter("Min_HeightMin", min_HeightMin) :
                new ObjectParameter("Min_HeightMin", typeof(decimal));
    
            var max_HeightMaxParameter = max_HeightMax.HasValue ?
                new ObjectParameter("Max_HeightMax", max_HeightMax) :
                new ObjectParameter("Max_HeightMax", typeof(decimal));
    
            var min_HeightMaxParameter = min_HeightMax.HasValue ?
                new ObjectParameter("Min_HeightMax", min_HeightMax) :
                new ObjectParameter("Min_HeightMax", typeof(decimal));
    
            var max_WeightParameter = max_Weight.HasValue ?
                new ObjectParameter("Max_Weight", max_Weight) :
                new ObjectParameter("Max_Weight", typeof(decimal));
    
            var min_WeightParameter = min_Weight.HasValue ?
                new ObjectParameter("Min_Weight", min_Weight) :
                new ObjectParameter("Min_Weight", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spGetProductDetails", productIDParameter, subCategoryIDParameter, max_AirFlowParameter, min_AirFlowParameter, max_PowerMinParameter, min_PowerMinParameter, max_PowerMaxParameter, min_PowerMaxParameter, max_VACMinParameter, min_VACMinParameter, max_VACMAXParameter, min_VACMAXParameter, max_FanSpeedMinParameter, min_FanSpeedMinParameter, max_FanSpeedMaxParameter, min_FanSpeedMaxParameter, max_NumberofFanSpeedParameter, min_NumberofFanSpeedParameter, max_SoundAtMaxSpeedParameter, min_SoundAtMaxSpeedParameter, max_FanSweepDiameterParameter, min_FanSweepDiameterParameter, max_HeightMinParameter, min_HeightMinParameter, max_HeightMaxParameter, min_HeightMaxParameter, max_WeightParameter, min_WeightParameter);
        }
    }
}
