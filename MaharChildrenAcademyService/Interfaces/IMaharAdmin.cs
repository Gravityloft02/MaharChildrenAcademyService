using MaharChildrenAcademyService.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaharChildrenAcademyService.Interfaces
{
   public interface IMaharAdmin
    {
        public Task<bool> AddAlbum(CustomAlbum album); 
    }
}
