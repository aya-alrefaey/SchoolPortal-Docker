using grade_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace grade_mvc.Viewmodels
{
    public class CreateViewmodel
    {
        
        public Grade Grade { get; set; }
        public List<studentInfo>? Students { get; set; }
    }
}