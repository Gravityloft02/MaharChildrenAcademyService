using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaharChildrenAcademyService.Models.Custom
{
    public class CustomAlbum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public int Flag { get; set; }
    }
}
