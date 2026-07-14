using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Persistence.Repositories
{
    public class BarcodeRepository : GenericRepository, IBarcodeRepository
    {
        private IConfiguration _configuration;
        private IFileManager _fileManager;
        private IConfigRefRepository _configRefRepository;

        public BarcodeRepository(IConfiguration configuration, IFileManager fileManager, IConfigRefRepository configRefRepository) : base(configuration)
        {
            _configuration = configuration;
            _fileManager = fileManager;
            _configRefRepository = configRefRepository;
        }

        public BarcodeGenerate_Response GenerateBarcode(string value, string barcodeType)
        {
            var vBarcodeGenerate = new BarcodeGenerate_Response();

            //Call API
            var vConfigRef_Search = new ConfigRef_Search()
            {
                Ref_Type = "Barcode",
                Ref_Param = "APIHostLink"
            };

            string barcodeBaseApi = string.Empty;
            var vConfigRefObj = _configRefRepository.GetConfigRefList(vConfigRef_Search).Result.ToList().FirstOrDefault();
            if (vConfigRefObj != null)
            {
                barcodeBaseApi = vConfigRefObj.Ref_Value1;
            }

            if (string.IsNullOrWhiteSpace(barcodeBaseApi))
            {
                return vBarcodeGenerate;
            }

            //Prepare you post parameters  
            var postData = new BarcodeGenerate_Request()
            {
                value = value
            };

            var jsonData = JsonConvert.SerializeObject(postData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string responseString;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsync(barcodeBaseApi, content).Result;
                response.EnsureSuccessStatusCode();
                responseString = response.Content.ReadAsStringAsync().Result;
            }

            dynamic jsonResults = JsonConvert.DeserializeObject<dynamic>(responseString);
            var status = jsonResults.ContainsKey("isSuccess") ? jsonResults.isSuccess : false;

            if (status == true)
            {
                var barcode = jsonResults["barcode"];

                var barcode_image_base64 = barcode.ContainsKey("barcode_image_base64") ? barcode.barcode_image_base64 : string.Empty;
                var vbarcode_image_base64 = Convert.ToString(barcode_image_base64);

                var unique_id = barcode.ContainsKey("unique_id") ? barcode.unique_id : string.Empty;
                var vUniqueId = Convert.ToString(unique_id);

                if (!string.IsNullOrWhiteSpace(vbarcode_image_base64))
                {
                    var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(vbarcode_image_base64, "\\Uploads\\Barcode\\" + barcodeType + "\\", vUniqueId + ".png");
                    if (!string.IsNullOrWhiteSpace(vUploadFile))
                    {
                        vBarcodeGenerate.Barcode_Unique_Id = vUniqueId;
                        vBarcodeGenerate.BarcodeOriginalFileName = vUniqueId + ".png";
                        vBarcodeGenerate.BarcodeFileName = vUploadFile;

                    }
                }
            }

            return vBarcodeGenerate;
        }

        public async Task<int> SaveBarcode(Barcode_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@BarcodeNo", parameters.BarcodeNo);
            queryParameters.Add("@BarcodeType", parameters.BarcodeType);
            queryParameters.Add("@Barcode_Unique_Id", parameters.Barcode_Unique_Id);
            queryParameters.Add("@BarcodeOriginalFileName", parameters.BarcodeOriginalFileName);
            queryParameters.Add("@BarcodeFileName", parameters.BarcodeFileName);
            queryParameters.Add("@RefId", parameters.RefId);

            return await SaveByStoredProcedure<int>("SaveBarcode", queryParameters);
        }

        public async Task<Barcode_Response?> GetBarcodeById(string BarcodeNo)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@BarcodeNo", BarcodeNo);

            return (await ListByStoredProcedure<Barcode_Response>("GetBarcodeById", queryParameters)).FirstOrDefault();
        }
    }
}
