using System;
using System.Collections.Generic;

#nullable disable

namespace MaharChildrenAcademyService.Models
{
    public partial class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public string Image { get; set; }
        public DateTime? Date { get; set; }
        public string Day { get; set; }
        public int? Flag { get; set; }
    }
}
