using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaharChildrenAcademyService.Interfaces;
using MaharChildrenAcademyService.Models;

namespace MaharChildrenAcademyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : BaseController
    {
        IUpload _upload;
        public DocumentController(IUpload upload)
        {
            _upload = upload;
        }

        [HttpPost("Upload")]
        public async Task<string> UploadDocuments(DocumentModel request)
        {
            var responese = await _upload.DocumentUploadAsync(request);

            return responese;
        }
    }
}
