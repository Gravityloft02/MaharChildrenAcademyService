using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MaharChildrenAcademyService.Models;

namespace MaharChildrenAcademyService.Services
{
    public class BaseUploadService: BaseService
    {
        public async Task<string> DocumentUploadAsync(string baseUrl, string callUrl, DocumentModel data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var formContent = new MultipartFormDataContent())
                    {
                        //formContent.Headers.ContentType.MediaType = "multipart/form-data";
                        HttpContent content = null;
                        if (data != null)
                        {
                            content = GetRequestContent(data);
                        }
                        else
                        {
                            content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                        }
                        //formContent.Add(content);
                        client.BaseAddress = new Uri(baseUrl);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                        HttpResponseMessage response;

                        response = await client.PostAsync(callUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await GetResult(response, false);
                            return result;
                        }
                        else
                        {
                            Exception ex = new Exception(JsonConvert.SerializeObject(response));
                            return string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
    }
}
