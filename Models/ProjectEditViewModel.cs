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

        public List<ProjectLaborItem> projectLaborItems { get; set; }
        public List<ProjectMaterial> projectMaterials { get; set; }

        static ProjectEditViewModel() {
            Materials = new Dictionary<int, string>()
            {
                { 0, "No Preference"},
                { 1, "I hate eggs"},
                { 2, "Over Easy"},
                { 3, "Sunny Side Up"},
                { 4, "Scrambled"},
                { 5, "Hard Boiled"},
                { 6, "Eggs Benedict"}
            };
        }

    }
}