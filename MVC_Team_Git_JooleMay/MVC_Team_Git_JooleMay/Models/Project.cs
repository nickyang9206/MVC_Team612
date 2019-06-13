using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay.Models
{
    public class ProjectLine
    {
        public Product Product { get; set; }
        public int ProjectID { get; set; }
        public int ProjectName { get; set; }
    }

    public class Project
    {
        private List<ProjectLine> lineCollection = new List<ProjectLine>();

        public void AddItem(Product product, int projectID)
        {
            ProjectLine line = lineCollection.FirstOrDefault(p => p.Product.ProductID == product.ProductID);

            if (line == null)
            {
                lineCollection.Add(new ProjectLine { Product = product, ProjectID = projectID });
            }
        }

        //public void RemoveLine(ProjectLine product)
        //{
        //    lineCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        //}

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<ProjectLine> Lines
        {
            get { return lineCollection; }
        }
    }
}