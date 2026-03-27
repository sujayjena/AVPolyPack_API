using AVPolyPack.API.Controllers;
using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;

namespace AVPolyPack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageSupplierController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IManageSupplierRepository _manageSupplierRepository;
        private IFileManager _fileManager;

        public ManageSupplierController(IManageSupplierRepository manageSupplierRepository, IFileManager fileManager)
        {
            _manageSupplierRepository = manageSupplierRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSupplier(Supplier_Request parameters)
        {
            // PanCard Upload
            if (parameters! != null && !string.IsNullOrWhiteSpace(parameters.PanCard_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.PanCard_Base64, "\\Uploads\\Supplier\\", parameters.PanCardOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.PanCardFileName = vUploadFile;
                }
            }

            // GST Upload
            if (parameters! != null && !string.IsNullOrWhiteSpace(parameters.GST_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.GST_Base64, "\\Uploads\\Supplier\\", parameters.GSTOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.GSTFileName = vUploadFile;
                }
            }

            int result = await _manageSupplierRepository.SaveSupplier(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                if (parameters.Id > 0)
                {
                    _response.Message = "Record updated successfully";
                }
                else
                {
                    _response.Message = "Record details saved successfully";
                }
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSupplierList(Supplier_Search parameters)
        {
            IEnumerable<Supplier_Response> lstRoles = await _manageSupplierRepository.GetSupplierList(parameters);

            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSupplierById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageSupplierRepository.GetSupplierById(Id);

                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> DownloadSupplierTemplate()
        {
            byte[]? formatFile = await Task.Run(() => _fileManager.GetFormatFileFromPath("Template_Supplier.xlsx"));

            if (formatFile != null)
            {
                _response.Data = formatFile;
            }

            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ImportSupplier([FromQuery] ImportRequest request)
        {
            byte[] result;
            _response.IsSuccess = false;

            int noOfCol, noOfRow;
            bool tableHasNull = false;

            List<Supplier_ImportData> lstImportRequestModel = new List<Supplier_ImportData>();

            DataTable dtTable;

            IEnumerable<Supplier_ImportDataValidation> lst_ImportDataValidation_Result;

            ExcelWorksheets currentSheet;
            ExcelWorksheet workSheet;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            if (request.FileUpload == null || request.FileUpload.Length == 0)
            {
                _response.Message = "Please upload an excel file";
                return _response;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                request.FileUpload.CopyTo(stream);
                using ExcelPackage package = new ExcelPackage(stream);
                currentSheet = package.Workbook.Worksheets;

                workSheet = currentSheet[0];
                noOfCol = workSheet.Dimension.End.Column;
                noOfRow = workSheet.Dimension.End.Row;

                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                {
                    if (!string.IsNullOrWhiteSpace(workSheet.Cells[rowIterator, 1].Value?.ToString()) && !string.IsNullOrWhiteSpace(workSheet.Cells[rowIterator, 2].Value?.ToString()))
                    {
                        Supplier_ImportData record = new Supplier_ImportData();
                        record.SupplierCode = workSheet.Cells[rowIterator, 1].Value != null ? workSheet.Cells[rowIterator, 1].Value.ToString() : null;
                        record.SupplierName = workSheet.Cells[rowIterator, 2].Value != null ? workSheet.Cells[rowIterator, 2].Value.ToString() : null;
                        record.CustomerName = workSheet.Cells[rowIterator, 3].Value != null ? workSheet.Cells[rowIterator, 3].Value.ToString() : null;
                        record.GroupName = workSheet.Cells[rowIterator, 4].Value != null ? workSheet.Cells[rowIterator, 4].Value.ToString() : null;
                        record.ReferenceFrom = workSheet.Cells[rowIterator, 5].Value != null ? workSheet.Cells[rowIterator, 5].Value.ToString() : null;
                        record.MobileNo1 = workSheet.Cells[rowIterator, 6].Value != null ? workSheet.Cells[rowIterator, 6].Value.ToString() : null;
                        record.MobileNo2 = workSheet.Cells[rowIterator, 7].Value != null ? workSheet.Cells[rowIterator, 7].Value.ToString() : null;
                        record.EmailId1 = workSheet.Cells[rowIterator, 8].Value != null ? workSheet.Cells[rowIterator, 8].Value.ToString() : null;
                        record.EmailId2 = workSheet.Cells[rowIterator, 9].Value != null ? workSheet.Cells[rowIterator, 9].Value.ToString() : null;
                        record.Website = workSheet.Cells[rowIterator, 10].Value != null ? workSheet.Cells[rowIterator, 10].Value.ToString() : null;
                        record.SpecialRemark = workSheet.Cells[rowIterator, 11].Value != null ? workSheet.Cells[rowIterator, 11].Value.ToString() : null;
                        record.CompanyRemark = workSheet.Cells[rowIterator, 12].Value != null ? workSheet.Cells[rowIterator, 12].Value.ToString() : null;
                        record.PanCardNumber = workSheet.Cells[rowIterator, 13].Value != null ? workSheet.Cells[rowIterator, 13].Value.ToString() : null;
                        record.GSTNumber = workSheet.Cells[rowIterator, 14].Value != null ? workSheet.Cells[rowIterator, 14].Value.ToString() : null;
                        record.ContactPerson = workSheet.Cells[rowIterator, 15].Value != null ? workSheet.Cells[rowIterator, 15].Value.ToString() : null;
                        record.ContactMobileNo = workSheet.Cells[rowIterator, 16].Value != null ? workSheet.Cells[rowIterator, 16].Value.ToString() : null;
                        record.ContactEmailId = workSheet.Cells[rowIterator, 17].Value != null ? workSheet.Cells[rowIterator, 17].Value.ToString() : null;
                        record.BankName = workSheet.Cells[rowIterator, 18].Value != null ? workSheet.Cells[rowIterator, 18].Value.ToString() : null;
                        record.BankAddress = workSheet.Cells[rowIterator, 19].Value != null ? workSheet.Cells[rowIterator, 19].Value.ToString() : null;
                        record.BankAccount = workSheet.Cells[rowIterator, 20].Value != null ? workSheet.Cells[rowIterator, 20].Value.ToString() : null;
                        record.BankIFSCCode = workSheet.Cells[rowIterator, 21].Value != null ? workSheet.Cells[rowIterator, 21].Value.ToString() : null;
                        record.AddressLine1 = workSheet.Cells[rowIterator, 22].Value != null ? workSheet.Cells[rowIterator, 22].Value.ToString() : null;
                        record.AddressLine2 = workSheet.Cells[rowIterator, 23].Value != null ? workSheet.Cells[rowIterator, 23].Value.ToString() : null;
                        record.Country = workSheet.Cells[rowIterator, 24].Value != null ? workSheet.Cells[rowIterator, 24].Value.ToString() : null;
                        record.State = workSheet.Cells[rowIterator, 25].Value != null ? workSheet.Cells[rowIterator, 25].Value.ToString() : null;
                        record.District = workSheet.Cells[rowIterator, 26].Value != null ? workSheet.Cells[rowIterator, 26].Value.ToString() : null;
                        record.City = workSheet.Cells[rowIterator, 27].Value != null ? workSheet.Cells[rowIterator, 27].Value.ToString() : null;
                        record.Pincode = workSheet.Cells[rowIterator, 28].Value != null ? workSheet.Cells[rowIterator, 28].Value.ToString() : null;
                        record.IsActive = workSheet.Cells[rowIterator, 29].Value != null ? workSheet.Cells[rowIterator, 29].Value.ToString() : null;

                        lstImportRequestModel.Add(record);
                    }
                }

                if (lstImportRequestModel.Count == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Uploaded customerfdata file does not contains any record";
                    return _response;
                }
                ;

                dtTable = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lstImportRequestModel), typeof(DataTable));

                //Excel Column Mismatch check. If column name has been changed then it's value will be null;
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn col in dtTable.Columns)
                    {
                        if (row[col] == DBNull.Value)
                        {
                            tableHasNull = true;
                            break;
                        }
                    }
                }

                //if (tableHasNullCustomer || tableHasNullCustomerContact || tableHasNullCustomerAddress)
                //{
                //    _response.IsSuccess = false;
                //    _response.Message = "Please upload a valid excel file. Please Download Format file for reference.";
                //    return _response;
                //}

                // Import Data
                lst_ImportDataValidation_Result = await _manageSupplierRepository.ImportSupplier(lstImportRequestModel);

                if (lst_ImportDataValidation_Result.ToList().Count == 0)
                {
                    _response.IsSuccess = true;
                    _response.Message = "Record imported successfully";
                }
                else
                {
                    _response.IsSuccess = true;
                    _response.Message = "Invalid record exist.";
                }

                #region Generate Excel file for Invalid Data

                if (lst_ImportDataValidation_Result.ToList().Count > 0)
                {
                    _response.IsSuccess = false;

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (ExcelPackage excelInvalidData = new ExcelPackage())
                        {
                            if (lst_ImportDataValidation_Result.ToList().Count > 0)
                            {
                                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                                int recordIndex;
                                ExcelWorksheet WorkSheet1 = excelInvalidData.Workbook.Worksheets.Add("Invalid_Supplier_Records");
                                WorkSheet1.TabColor = System.Drawing.Color.Black;
                                WorkSheet1.DefaultRowHeight = 12;

                                //Header of table
                                WorkSheet1.Row(1).Height = 20;
                                WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                WorkSheet1.Row(1).Style.Font.Bold = true;

                                WorkSheet1.Cells[1, 1].Value = "SupplierCode";
                                WorkSheet1.Cells[1, 2].Value = "SupplierName";
                                WorkSheet1.Cells[1, 3].Value = "CustomerName";
                                WorkSheet1.Cells[1, 4].Value = "GroupName";
                                WorkSheet1.Cells[1, 5].Value = "ReferenceFrom";
                                WorkSheet1.Cells[1, 6].Value = "MobileNo1";
                                WorkSheet1.Cells[1, 7].Value = "MobileNo2";
                                WorkSheet1.Cells[1, 8].Value = "EmailId1";
                                WorkSheet1.Cells[1, 9].Value = "EmailId2";
                                WorkSheet1.Cells[1, 10].Value = "Website";
                                WorkSheet1.Cells[1, 11].Value = "SpecialRemark";
                                WorkSheet1.Cells[1, 12].Value = "CompanyRemark";
                                WorkSheet1.Cells[1, 13].Value = "PanCardNumber";
                                WorkSheet1.Cells[1, 14].Value = "GSTNumber";
                                WorkSheet1.Cells[1, 15].Value = "ContactPerson";
                                WorkSheet1.Cells[1, 16].Value = "ContactMobileNo";
                                WorkSheet1.Cells[1, 17].Value = "ContactEmailId";
                                WorkSheet1.Cells[1, 18].Value = "BankName";
                                WorkSheet1.Cells[1, 19].Value = "BankAddress";
                                WorkSheet1.Cells[1, 20].Value = "BankAccount";
                                WorkSheet1.Cells[1, 21].Value = "BankIFSCCode";
                                WorkSheet1.Cells[1, 22].Value = "AddressLine1";
                                WorkSheet1.Cells[1, 23].Value = "AddressLine2";
                                WorkSheet1.Cells[1, 24].Value = "Country";
                                WorkSheet1.Cells[1, 25].Value = "State";
                                WorkSheet1.Cells[1, 26].Value = "District";
                                WorkSheet1.Cells[1, 27].Value = "City";
                                WorkSheet1.Cells[1, 28].Value = "Pincode";
                                WorkSheet1.Cells[1, 29].Value = "IsActive";
                                WorkSheet1.Cells[1, 30].Value = "ValidationMessage";

                                recordIndex = 2;

                                foreach (Supplier_ImportDataValidation record in lst_ImportDataValidation_Result)
                                {
                                    WorkSheet1.Cells[recordIndex, 1].Value = record.SupplierCode;
                                    WorkSheet1.Cells[recordIndex, 2].Value = record.SupplierName;
                                    WorkSheet1.Cells[recordIndex, 3].Value = record.CustomerName;
                                    WorkSheet1.Cells[recordIndex, 4].Value = record.GroupName;
                                    WorkSheet1.Cells[recordIndex, 5].Value = record.ReferenceFrom;
                                    WorkSheet1.Cells[recordIndex, 6].Value = record.MobileNo1;
                                    WorkSheet1.Cells[recordIndex, 7].Value = record.MobileNo2;
                                    WorkSheet1.Cells[recordIndex, 8].Value = record.EmailId1;
                                    WorkSheet1.Cells[recordIndex, 9].Value = record.EmailId2;
                                    WorkSheet1.Cells[recordIndex, 10].Value = record.Website;
                                    WorkSheet1.Cells[recordIndex, 11].Value = record.SpecialRemark;
                                    WorkSheet1.Cells[recordIndex, 12].Value = record.CompanyRemark;
                                    WorkSheet1.Cells[recordIndex, 13].Value = record.PanCardNumber;
                                    WorkSheet1.Cells[recordIndex, 14].Value = record.GSTNumber;
                                    WorkSheet1.Cells[recordIndex, 15].Value = record.ContactPerson;
                                    WorkSheet1.Cells[recordIndex, 16].Value = record.ContactMobileNo;
                                    WorkSheet1.Cells[recordIndex, 17].Value = record.ContactEmailId;
                                    WorkSheet1.Cells[recordIndex, 18].Value = record.BankName;
                                    WorkSheet1.Cells[recordIndex, 19].Value = record.BankAddress;
                                    WorkSheet1.Cells[recordIndex, 20].Value = record.BankAccount;
                                    WorkSheet1.Cells[recordIndex, 21].Value = record.BankIFSCCode;
                                    WorkSheet1.Cells[recordIndex, 22].Value = record.AddressLine1;
                                    WorkSheet1.Cells[recordIndex, 23].Value = record.AddressLine2;
                                    WorkSheet1.Cells[recordIndex, 24].Value = record.Country;
                                    WorkSheet1.Cells[recordIndex, 25].Value = record.State;
                                    WorkSheet1.Cells[recordIndex, 26].Value = record.District;
                                    WorkSheet1.Cells[recordIndex, 27].Value = record.City;
                                    WorkSheet1.Cells[recordIndex, 28].Value = record.Pincode;
                                    WorkSheet1.Cells[recordIndex, 29].Value = record.IsActive;
                                    WorkSheet1.Cells[recordIndex, 30].Value = record.ValidationMessage;

                                    recordIndex += 1;
                                }

                                WorkSheet1.Columns.AutoFit();
                            }

                            excelInvalidData.SaveAs(memoryStream);
                            memoryStream.Position = 0;
                            result = memoryStream.ToArray();

                            _response.Data = result;
                        }
                    }
                }

                #endregion

                return _response;
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportSupplier(Supplier_Search parameters)
        {
            _response.IsSuccess = false;
            byte[] result;

            var lstListObj = await _manageSupplierRepository.GetSupplierList(parameters);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    int recordIndex;
                    ExcelWorksheet WorkSheet1 = excelExportData.Workbook.Worksheets.Add("Supplier");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Supplier Code";
                    WorkSheet1.Cells[1, 2].Value = "Supplier Name";
                    WorkSheet1.Cells[1, 3].Value = "Customer Name";
                    WorkSheet1.Cells[1, 4].Value = "Group Name";
                    WorkSheet1.Cells[1, 5].Value = "Reference From";
                    WorkSheet1.Cells[1, 6].Value = "Mobile # 1";
                    WorkSheet1.Cells[1, 7].Value = "Mobile # 2";
                    WorkSheet1.Cells[1, 8].Value = "Email ID 1";
                    WorkSheet1.Cells[1, 9].Value = "Email ID 2";
                    WorkSheet1.Cells[1, 10].Value = "Website";
                    WorkSheet1.Cells[1, 11].Value = "Special Remark";
                    WorkSheet1.Cells[1, 12].Value = "Company Remark";
                    WorkSheet1.Cells[1, 13].Value = "PanCard Number";
                    WorkSheet1.Cells[1, 14].Value = "GST Number";
                    WorkSheet1.Cells[1, 15].Value = "Contact Person";
                    WorkSheet1.Cells[1, 16].Value = "Contact Mobile No.";
                    WorkSheet1.Cells[1, 17].Value = "Contact EmailId";
                    WorkSheet1.Cells[1, 18].Value = "Bank Name";
                    WorkSheet1.Cells[1, 19].Value = "Bank Address";
                    WorkSheet1.Cells[1, 20].Value = "Bank Account";
                    WorkSheet1.Cells[1, 21].Value = "Bank IFSC Code";
                    WorkSheet1.Cells[1, 22].Value = "AddressLine1";
                    WorkSheet1.Cells[1, 23].Value = "AddressLine2";
                    WorkSheet1.Cells[1, 24].Value = "Country";
                    WorkSheet1.Cells[1, 25].Value = "State";
                    WorkSheet1.Cells[1, 26].Value = "District";
                    WorkSheet1.Cells[1, 27].Value = "City";
                    WorkSheet1.Cells[1, 28].Value = "Pincode";
                    WorkSheet1.Cells[1, 29].Value = "IsActive";
                    WorkSheet1.Cells[1, 30].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 31].Value = "CreatedBy";

                    recordIndex = 2;
                    foreach (var items in lstListObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.SupplierCode;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.SupplierName;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.CustomerName;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.GroupName;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.ReferenceName;
                        WorkSheet1.Cells[recordIndex, 6].Value = items.MobileNumber1;
                        WorkSheet1.Cells[recordIndex, 7].Value = items.MobileNumber2;
                        WorkSheet1.Cells[recordIndex, 8].Value = items.EmailId1;
                        WorkSheet1.Cells[recordIndex, 9].Value = items.EmailId2;
                        WorkSheet1.Cells[recordIndex, 10].Value = items.Website;
                        WorkSheet1.Cells[recordIndex, 11].Value = items.SpecialRemarks;
                        WorkSheet1.Cells[recordIndex, 12].Value = items.CompanyRemarks;
                        WorkSheet1.Cells[recordIndex, 13].Value = items.PanCardNumber;
                        WorkSheet1.Cells[recordIndex, 14].Value = items.GSTNumber;
                        WorkSheet1.Cells[recordIndex, 15].Value = items.ContactPersonName;
                        WorkSheet1.Cells[recordIndex, 16].Value = items.ContactPersonMobileNumber;
                        WorkSheet1.Cells[recordIndex, 17].Value = items.ContactPersonEmailId;
                        WorkSheet1.Cells[recordIndex, 18].Value = items.BankName;
                        WorkSheet1.Cells[recordIndex, 19].Value = items.BankAddress;
                        WorkSheet1.Cells[recordIndex, 20].Value = items.BankAccountNo;
                        WorkSheet1.Cells[recordIndex, 21].Value = items.BankIFSCCode;
                        WorkSheet1.Cells[recordIndex, 22].Value = items.AddressLine1;
                        WorkSheet1.Cells[recordIndex, 23].Value = items.AddressLine2;
                        WorkSheet1.Cells[recordIndex, 24].Value = items.CountryName;
                        WorkSheet1.Cells[recordIndex, 25].Value = items.StateName;
                        WorkSheet1.Cells[recordIndex, 26].Value = items.DistrictName;
                        WorkSheet1.Cells[recordIndex, 27].Value = items.CityName;
                        WorkSheet1.Cells[recordIndex, 28].Value = items.PinCode;
                        WorkSheet1.Cells[recordIndex, 29].Value = items.IsActive == true ? "Active" : "Inactive";
                        WorkSheet1.Cells[recordIndex, 30].Value = Convert.ToDateTime(items.CreatedDate).ToString("dd/MM/yyyy");
                        WorkSheet1.Cells[recordIndex, 31].Value = items.CreatorName;

                        recordIndex += 1;
                    }

                    WorkSheet1.Columns.AutoFit();

                    excelExportData.SaveAs(msExportDataFile);
                    msExportDataFile.Position = 0;
                    result = msExportDataFile.ToArray();
                }
            }


            if (result != null)
            {
                _response.Data = result;
                _response.IsSuccess = true;
                _response.Message = "Exported successfully";
            }

            return _response;
        }
    }
}
