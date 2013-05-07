using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJCProjectEstimatorMVC.Models
{
    public class ProjectEditViewModel : BaseViewModel
    {
        public static Dictionary<int, string> Materials { get; set; }

        public Project project { get; set; }
        public ProjectLaborItem projectLaborItem { get; set; }
        public ProjectMaterial projectMaterial { get; set; }
        
        public List<ProjectMaterialViewModel> projectMaterialViewModels { get; set; }
        public List<ProjectLaborItem> projectLaborItems { get; set; }
        public List<ProjectMaterial> projectMaterials { get; set; }

        public ProjectReportLineViewModel ProjectCosts { get; set; }

        static ProjectEditViewModel() {
            Materials = new Dictionary<int, string>();

            DBContext db = new DBContext();
            IOrderedEnumerable<Material> materialsList = (IOrderedEnumerable<Material>) db.Materials.ToList().OrderBy(x => x.Name);

            foreach (Material m in materialsList)
            {
                Materials.Add(m.MaterialId, m.Name);
            }


    
        }

    }
}