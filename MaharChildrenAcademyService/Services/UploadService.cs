using MaharChildrenAcademyService.Interfaces;
using MaharChildrenAcademyService.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaharChildrenAcademyService.Services
{
    public class UploadService:BaseUploadService, IUpload
    {
        private readonly AppSetting _options;

        public UploadService(IOptions<AppSetting> options)
        {
            _options = options.Value;
        }

        public async Task<string> DocumentUploadAsync(DocumentModel data)
        {
            var result = await DocumentUploadAsync(_options.UploadBaseURL,_options.UploadApi,data); 
            return result;
        }
    }
}
