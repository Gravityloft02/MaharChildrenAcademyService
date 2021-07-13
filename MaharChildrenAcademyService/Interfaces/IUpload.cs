using MaharChildrenAcademyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaharChildrenAcademyService.Interfaces
{
    public interface IUpload
    {
        Task<string> DocumentUploadAsync(DocumentModel data);
    }
}
