using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaharChildrenAcademyService.Models
{
    public class AppSetting
    {
        public string MessagingBaseURL { get; set; }
        public string EmailApi { get; set; }
        public string SMSApi { get; set; }
        public string TextLocalKey { get; set; }
        public string MaharRegHeader { get; set; }
        public string BaseURL_PDF { get; set; }
        public string PDF_Api { get; set; }
        public string UploadBaseURL { get; set; }
        public string UploadApi { get; set; }
        //public string SuperAdmin { get; set; }
        //public string BusinessName { get; set; }
        //public string BusinessOwnerName { get; set; }
        //public string BusinessAddress { get; set; }
        //public string BusinessMobile { get; set; }
        //public string BusinessWhatsappNo { get; set; }
        //public string BusinessEmail { get; set; }
        //public string BusinessGstin { get; set; }
        //public string BusinessPanNo { get; set; }
        //public string BusinessAdhaarNo { get; set; }
        public string EncryptionKey { get; set; }
        public string WhatsApi { get; set; }
        public string ProfileApi { get; set; }
        public string Test { get; set; }
    }
}
