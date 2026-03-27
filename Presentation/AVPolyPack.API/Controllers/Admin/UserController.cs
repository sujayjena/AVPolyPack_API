using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Text;

namespace AVPolyPack.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private IFileManager _fileManager;

        public UserController(IUserRepository userRepository, ICompanyRepository companyRepository, IFileManager fileManager)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region User 

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveUser(User_Request parameters)
        {
            // Aadhar Card Upload
            if (parameters! != null && !string.IsNullOrWhiteSpace(parameters.AadharImage_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.AadharImage_Base64, "\\Uploads\\Employee\\", parameters.AadharOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.AadharImage = vUploadFile;
                }
            }

            // Aadhar Card Back Upload
            if (parameters! != null && !string.IsNullOrWhiteSpace(parameters.AadharBack_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.AadharBack_Base64, "\\Uploads\\Employee\\", parameters.AadharBackOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.AadharBackFileName = vUploadFile;
                }
            }

            // Pan Card Upload
            if (parameters != null && !string.IsNullOrWhiteSpace(parameters.PanCardImage_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.PanCardImage_Base64, "\\Uploads\\Employee\\", parameters.PanCardOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.PanCardImage = vUploadFile;
                }
            }

            // Profile Upload
            if (parameters != null && !string.IsNullOrWhiteSpace(parameters.ProfileImage_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.ProfileImage_Base64, "\\Uploads\\Employee\\", parameters.ProfileOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.ProfileImage = vUploadFile;
                }
            }

            // Other Proof Upload
            if (parameters != null && !string.IsNullOrWhiteSpace(parameters.OtherProof_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.OtherProof_Base64, "\\Uploads\\Employee\\", parameters.OtherProofOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.OtherProofFileName = vUploadFile;
                }
            }

            // Bank Details Upload
            if (parameters != null && !string.IsNullOrWhiteSpace(parameters.BankDetails_Base64))
            {
                var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(parameters.BankDetails_Base64, "\\Uploads\\Employee\\", parameters.BankDetailsOriginalFileName);

                if (!string.IsNullOrWhiteSpace(vUploadFile))
                {
                    parameters.BankDetailsFileName = vUploadFile;
                }
            }

            int result = await _userRepository.SaveUser(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == -3)
            {
                _response.Message = "Email already exists";
            }
            else if (result == -4)
            {
                _response.Message = "Mobile # already exists";
            }
            else if (result == -5)
            {
                _response.Message = "Aadhar # already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                if (parameters.Id == 0)
                {
                    _response.Message = "Record Submitted successfully";
                }
                else
                {
                    _response.Message = "Record Updated successfully";
                }

                foreach (var item in parameters.UserDetailsList)
                {
                    var vUserOtherDetails_Request = new UserOtherDetails_Request()
                    {
                        Id = item.Id,
                        EmployeeId = result,
                        PastCompanyName = item.PastCompanyName,
                        TotalExp = item.TotalExp,
                        Remarks = item.Remarks,
                    };

                    int resultExpenseDetails = await _userRepository.SaveUserOtherDetails(vUserOtherDetails_Request);
                }
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetUserList(User_Search parameters)
        {
            IEnumerable<User_Response> lstUsers = await _userRepository.GetUserList(parameters);
            _response.Data = lstUsers.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetUserById(long Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _userRepository.GetUserById(Id);
                if (vResultObj != null)
                {
                    var vUserOtherDetails_Search = new UserOtherDetails_Search();
                    vUserOtherDetails_Search.EmployeeId = vResultObj.Id;

                    var vList = await _userRepository.GetUserOtherDetailsList(vUserOtherDetails_Search);

                    vResultObj.UserDetailsList = vList.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetUserLisByRoleIdOrRoleName(UserListByRole_Search parameters)
        {
            IEnumerable<UserListByRole_Response> lstUsers = await _userRepository.GetUserLisByRoleIdOrRoleName(parameters);
            _response.Data = lstUsers.ToList();
            return _response;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> DownloadUserTemplate()
        {
            byte[]? formatFile = await Task.Run(() => _fileManager.GetFormatFileFromPath("Template_User.xlsx"));

            if (formatFile != null)
            {
                _response.Data = formatFile;
            }

            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ImportUser([FromQuery] ImportRequest request)
        {
            _response.IsSuccess = false;

            ExcelWorksheets currentSheet;
            ExcelWorksheet workSheet;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            int noOfCol, noOfRow;

            List<string[]> data = new List<string[]>();
            List<User_ImportData> lstUser_ImportData = new List<User_ImportData>();
            IEnumerable<User_ImportDataValidation> lstUser_ImportDataValidation;

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
                workSheet = currentSheet.First();
                noOfCol = workSheet.Dimension.End.Column;
                noOfRow = workSheet.Dimension.End.Row;

                if (!string.Equals(workSheet.Cells[1, 1].Value.ToString(), "UserCode", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 2].Value.ToString(), "UserName", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 3].Value.ToString(), "EmployeeType", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 4].Value.ToString(), "MobileNumber", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 5].Value.ToString(), "Password", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 6].Value.ToString(), "Role", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 7].Value.ToString(), "ReportingTo", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 8].Value.ToString(), "Department", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 9].Value.ToString(), "Company", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 10].Value.ToString(), "Address", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 11].Value.ToString(), "Country", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 12].Value.ToString(), "State", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 13].Value.ToString(), "District", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 14].Value.ToString(), "City", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 15].Value.ToString(), "Pincode", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 16].Value.ToString(), "DateOfBirth", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 17].Value.ToString(), "DateOfJoining", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 18].Value.ToString(), "EmergencyName", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 19].Value.ToString(), "EmergencyContactNumber", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 20].Value.ToString(), "EmergencyRelation", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 21].Value.ToString(), "BloodGroup", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 22].Value.ToString(), "Gender", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 23].Value.ToString(), "MaritalStatus", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 24].Value.ToString(), "WorkingHour", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 25].Value.ToString(), "Rate", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 26].Value.ToString(), "RateValue", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 27].Value.ToString(), "BankName", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 28].Value.ToString(), "BankAccountNo", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 29].Value.ToString(), "BankIFSCCode", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 30].Value.ToString(), "AadharNumber", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 31].Value.ToString(), "PanNumber", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 32].Value.ToString(), "OtherProof", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 33].Value.ToString(), "IsSupervisor", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 34].Value.ToString(), "IsMobileUser", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 35].Value.ToString(), "IsWebUser", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(workSheet.Cells[1, 36].Value.ToString(), "IsActive", StringComparison.OrdinalIgnoreCase))
                {
                    _response.IsSuccess = false;
                    _response.Message = "Please upload a valid excel file";
                    return _response;
                }

                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                {
                    if (!string.IsNullOrWhiteSpace(workSheet.Cells[rowIterator, 2].Value?.ToString()) && !string.IsNullOrWhiteSpace(workSheet.Cells[rowIterator, 3].Value?.ToString()))
                    {
                        lstUser_ImportData.Add(new User_ImportData()
                        {
                            UserCode = workSheet.Cells[rowIterator, 1].Value?.ToString(),
                            UserName = workSheet.Cells[rowIterator, 2].Value?.ToString(),
                            EmployeeType = workSheet.Cells[rowIterator, 3].Value?.ToString(),
                            MobileNumber = workSheet.Cells[rowIterator, 4].Value?.ToString(),
                            Password = !string.IsNullOrWhiteSpace(workSheet.Cells[rowIterator, 5].Value?.ToString()) ? EncryptDecryptHelper.EncryptString(workSheet.Cells[rowIterator, 5].Value?.ToString()) : string.Empty,
                            Role = workSheet.Cells[rowIterator, 6].Value?.ToString(),
                            ReportingTo = workSheet.Cells[rowIterator, 7].Value?.ToString(),
                            Department = workSheet.Cells[rowIterator, 8].Value?.ToString(),
                            Company = workSheet.Cells[rowIterator, 9].Value?.ToString(),
                            Address = workSheet.Cells[rowIterator, 10].Value?.ToString(),
                            Country = workSheet.Cells[rowIterator, 11].Value?.ToString(),
                            State = workSheet.Cells[rowIterator, 12].Value?.ToString(),
                            District = workSheet.Cells[rowIterator, 13].Value?.ToString(),
                            City = workSheet.Cells[rowIterator, 14].Value?.ToString(),
                            Pincode = workSheet.Cells[rowIterator, 15].Value?.ToString(),
                            DateOfBirth = !string.IsNullOrWhiteSpace(workSheet.Cells[rowIterator, 16].Value?.ToString()) ? DateTime.ParseExact(workSheet.Cells[rowIterator, 16].Value?.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat) : null,
                            DateOfJoining = !string.IsNullOrWhiteSpace(workSheet.Cells[rowIterator, 17].Value?.ToString()) ? DateTime.ParseExact(workSheet.Cells[rowIterator, 17].Value?.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat) : null,
                            EmergencyName = workSheet.Cells[rowIterator, 18].Value?.ToString(),
                            EmergencyContactNumber = workSheet.Cells[rowIterator, 19].Value?.ToString(),
                            EmergencyRelation = workSheet.Cells[rowIterator, 20].Value?.ToString(),
                            BloodGroup = workSheet.Cells[rowIterator, 21].Value?.ToString(),
                            Gender = workSheet.Cells[rowIterator, 22].Value?.ToString(),
                            MaritalStatus = workSheet.Cells[rowIterator, 23].Value?.ToString(),
                            WorkingHour = workSheet.Cells[rowIterator, 24].Value?.ToString(),
                            Rate = workSheet.Cells[rowIterator, 25].Value?.ToString(),
                            RateValue = workSheet.Cells[rowIterator, 26].Value?.ToString(),
                            BankName = workSheet.Cells[rowIterator, 27].Value?.ToString(),
                            BankAccountNo = workSheet.Cells[rowIterator, 28].Value?.ToString(),
                            BankIFSCCode = workSheet.Cells[rowIterator, 29].Value?.ToString(),
                            AadharNumber = workSheet.Cells[rowIterator, 30].Value?.ToString(),
                            PanNumber = workSheet.Cells[rowIterator, 31].Value?.ToString(),
                            OtherProof = workSheet.Cells[rowIterator, 32].Value?.ToString(),
                            IsSupervisor = workSheet.Cells[rowIterator, 33].Value?.ToString(),
                            IsMobileUser = workSheet.Cells[rowIterator, 34].Value?.ToString(),
                            IsWebUser = workSheet.Cells[rowIterator, 35].Value?.ToString(),
                            IsActive = workSheet.Cells[rowIterator, 36].Value?.ToString()
                        });
                    }
                }
            }

            if (lstUser_ImportData.Count == 0)
            {
                _response.Message = "File does not contains any record(s)";
                return _response;
            }

            lstUser_ImportDataValidation = await _userRepository.ImportUser(lstUser_ImportData);

            _response.IsSuccess = true;
            _response.Message = "Record imported successfully";

            #region Generate Excel file for Invalid Data

            if (lstUser_ImportDataValidation.ToList().Count > 0)
            {
                _response.Message = "Uploaded file contains invalid records, please check downloaded file for more details";
                _response.Data = GenerateInvalidImportDataFile(lstUser_ImportDataValidation);
            }

            #endregion

            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportUserData(User_Search parameters)
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            IEnumerable<User_Response> lstSizeObj = await _userRepository.GetUserList(parameters);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("Employee");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "User Code";
                    WorkSheet1.Cells[1, 2].Value = "User Name";
                    WorkSheet1.Cells[1, 3].Value = "Mobile";
                    WorkSheet1.Cells[1, 4].Value = "Department";
                    WorkSheet1.Cells[1, 5].Value = "Role";
                    WorkSheet1.Cells[1, 6].Value = "ReportingTo";
                    WorkSheet1.Cells[1, 7].Value = "Gender";
                    WorkSheet1.Cells[1, 8].Value = "Marital Status ";
                    WorkSheet1.Cells[1, 9].Value = "Working Hrs";
                    WorkSheet1.Cells[1, 10].Value = "Rate";
                    WorkSheet1.Cells[1, 11].Value = "Rate Value";
                    WorkSheet1.Cells[1, 12].Value = "Company";
                    WorkSheet1.Cells[1, 13].Value = "Address";
                    WorkSheet1.Cells[1, 14].Value = "State";
                    WorkSheet1.Cells[1, 15].Value = "District";
                    WorkSheet1.Cells[1, 16].Value = "City";
                    WorkSheet1.Cells[1, 17].Value = "Pincode";
                    WorkSheet1.Cells[1, 18].Value = "Date Of Birth";
                    WorkSheet1.Cells[1, 19].Value = "Date Of Joining";
                    WorkSheet1.Cells[1, 20].Value = "Emergency Name";
                    WorkSheet1.Cells[1, 21].Value = "Emergency Contact Number";
                    WorkSheet1.Cells[1, 22].Value = "Emergency Relation";
                    WorkSheet1.Cells[1, 23].Value = "Bank Name";
                    WorkSheet1.Cells[1, 24].Value = "Bank A/C #";
                    WorkSheet1.Cells[1, 25].Value = "Bank IFSC Code";
                    WorkSheet1.Cells[1, 26].Value = "Blood Group";
                    WorkSheet1.Cells[1, 27].Value = "Aadhar Number";
                    WorkSheet1.Cells[1, 28].Value = "Pan Number";
                    WorkSheet1.Cells[1, 29].Value = "Other Proof";
                    WorkSheet1.Cells[1, 30].Value = "IsSupervisor";
                    WorkSheet1.Cells[1, 31].Value = "IsMobileUser";
                    WorkSheet1.Cells[1, 32].Value = "IsWebUser";
                    WorkSheet1.Cells[1, 33].Value = "IsActive";
                    WorkSheet1.Cells[1, 34].Value = "Created Date";
                    WorkSheet1.Cells[1, 35].Value = "Created By";

                    recordIndex = 2;

                    foreach (var items in lstSizeObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.UserCode;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.UserName;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.MobileNumber;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.DepartmentName;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.RoleName;
                        WorkSheet1.Cells[recordIndex, 6].Value = items.ReportingToName;
                        WorkSheet1.Cells[recordIndex, 7].Value = items.Gender;
                        WorkSheet1.Cells[recordIndex, 8].Value = items.MaritalStatus;
                        WorkSheet1.Cells[recordIndex, 9].Value = items.WorkingHour;
                        WorkSheet1.Cells[recordIndex, 10].Value = items.RateType == 1 ? "Daily Rate" : items.RateType == 2 ? "Monthly Rate" : "";
                        WorkSheet1.Cells[recordIndex, 11].Value = items.Rate;
                        WorkSheet1.Cells[recordIndex, 12].Value = items.CompanyName;

                        WorkSheet1.Cells[recordIndex, 13].Value = items.AddressLine;
                        WorkSheet1.Cells[recordIndex, 14].Value = items.StateName;
                        WorkSheet1.Cells[recordIndex, 15].Value = items.DistrictName;
                        WorkSheet1.Cells[recordIndex, 16].Value = items.CityName;
                        WorkSheet1.Cells[recordIndex, 17].Value = items.Pincode;
                        WorkSheet1.Cells[recordIndex, 18].Value = items.DateOfBirth.HasValue ? items.DateOfBirth.Value.ToString("dd/MM/yyyy") : string.Empty;
                        WorkSheet1.Cells[recordIndex, 19].Value = items.DateOfJoining.HasValue ? items.DateOfJoining.Value.ToString("dd/MM/yyyy") : string.Empty;
                        WorkSheet1.Cells[recordIndex, 20].Value = items.EmergencyName;
                        WorkSheet1.Cells[recordIndex, 21].Value = items.EmergencyContactNumber;
                        WorkSheet1.Cells[recordIndex, 22].Value = items.EmergencyRelation;
                        WorkSheet1.Cells[recordIndex, 23].Value = items.BankName;
                        WorkSheet1.Cells[recordIndex, 24].Value = items.BankAccountNo;
                        WorkSheet1.Cells[recordIndex, 25].Value = items.BankIFSCCode;
                        WorkSheet1.Cells[recordIndex, 26].Value = items.BloodGroupName;
                        WorkSheet1.Cells[recordIndex, 27].Value = items.AadharNumber;
                        WorkSheet1.Cells[recordIndex, 28].Value = items.PanNumber;
                        WorkSheet1.Cells[recordIndex, 29].Value = items.OtherProof;
                        WorkSheet1.Cells[recordIndex, 30].Value = items.IsSupervisor == true ? "Yes" : "No";
                        WorkSheet1.Cells[recordIndex, 31].Value = items.IsMobileUser == true ? "Yes" : "No";
                        WorkSheet1.Cells[recordIndex, 32].Value = items.IsWebUser == true ? "Yes" : "No";
                        WorkSheet1.Cells[recordIndex, 33].Value = items.IsActive == true ? "Active" : "Inactive";
                        WorkSheet1.Cells[recordIndex, 34].Value = Convert.ToDateTime(items.CreatedDate).ToString("dd/MM/yyyy");
                        WorkSheet1.Cells[recordIndex, 35].Value = items.CreatorName;

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

        private byte[] GenerateInvalidImportDataFile(IEnumerable<User_ImportDataValidation> lstUser_ImportDataValidation)
        {
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;

            using (MemoryStream msInvalidDataFile = new MemoryStream())
            {
                using (ExcelPackage excelInvalidData = new ExcelPackage())
                {
                    WorkSheet1 = excelInvalidData.Workbook.Worksheets.Add("Invalid_Records");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "UserCode";
                    WorkSheet1.Cells[1, 2].Value = "UserName";
                    WorkSheet1.Cells[1, 3].Value = "EmployeeType";
                    WorkSheet1.Cells[1, 4].Value = "MobileNumber";
                    WorkSheet1.Cells[1, 5].Value = "Password";
                    WorkSheet1.Cells[1, 6].Value = "Role";
                    WorkSheet1.Cells[1, 7].Value = "ReportingTo";
                    WorkSheet1.Cells[1, 8].Value = "Department";
                    WorkSheet1.Cells[1, 9].Value = "Company";
                    WorkSheet1.Cells[1, 10].Value = "Address";
                    WorkSheet1.Cells[1, 11].Value = "Country";
                    WorkSheet1.Cells[1, 12].Value = "State";
                    WorkSheet1.Cells[1, 13].Value = "District";
                    WorkSheet1.Cells[1, 14].Value = "City";
                    WorkSheet1.Cells[1, 15].Value = "Pincode";
                    WorkSheet1.Cells[1, 16].Value = "DateOfBirth";
                    WorkSheet1.Cells[1, 17].Value = "DateOfJoining";
                    WorkSheet1.Cells[1, 18].Value = "EmergencyName";
                    WorkSheet1.Cells[1, 19].Value = "EmergencyContactNumber";
                    WorkSheet1.Cells[1, 20].Value = "EmergencyRelation";
                    WorkSheet1.Cells[1, 21].Value = "BloodGroup";
                    WorkSheet1.Cells[1, 22].Value = "Gender";
                    WorkSheet1.Cells[1, 23].Value = "MaritalStatus";
                    WorkSheet1.Cells[1, 24].Value = "WorkingHour";
                    WorkSheet1.Cells[1, 25].Value = "Rate";
                    WorkSheet1.Cells[1, 26].Value = "RateValue";
                    WorkSheet1.Cells[1, 27].Value = "BankName";
                    WorkSheet1.Cells[1, 28].Value = "BankAccountNo";
                    WorkSheet1.Cells[1, 29].Value = "BankIFSCCode";
                    WorkSheet1.Cells[1, 30].Value = "AadharNumber";
                    WorkSheet1.Cells[1, 31].Value = "PanNumber";
                    WorkSheet1.Cells[1, 32].Value = "OtherProof";
                    WorkSheet1.Cells[1, 33].Value = "IsSupervisor";
                    WorkSheet1.Cells[1, 34].Value = "IsMobileUser";
                    WorkSheet1.Cells[1, 35].Value = "IsWebUser";
                    WorkSheet1.Cells[1, 36].Value = "IsActive";
                    WorkSheet1.Cells[1, 37].Value = "ErrorMessage";

                    recordIndex = 2;

                    foreach (User_ImportDataValidation record in lstUser_ImportDataValidation)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = record.UserCode;
                        WorkSheet1.Cells[recordIndex, 2].Value = record.UserName;
                        WorkSheet1.Cells[recordIndex, 3].Value = record.EmployeeType;
                        WorkSheet1.Cells[recordIndex, 4].Value = record.MobileNumber;
                        WorkSheet1.Cells[recordIndex, 5].Value = record.Password;
                        WorkSheet1.Cells[recordIndex, 6].Value = record.Role;
                        WorkSheet1.Cells[recordIndex, 7].Value = record.ReportingTo;
                        WorkSheet1.Cells[recordIndex, 8].Value = record.Department;
                        WorkSheet1.Cells[recordIndex, 9].Value = record.Company;
                        WorkSheet1.Cells[recordIndex, 10].Value = record.Address;
                        WorkSheet1.Cells[recordIndex, 11].Value = record.Country;
                        WorkSheet1.Cells[recordIndex, 12].Value = record.State;
                        WorkSheet1.Cells[recordIndex, 13].Value = record.District;
                        WorkSheet1.Cells[recordIndex, 14].Value = record.City;
                        WorkSheet1.Cells[recordIndex, 15].Value = record.Pincode;
                        WorkSheet1.Cells[recordIndex, 16].Value = record.DateOfBirth;
                        WorkSheet1.Cells[recordIndex, 17].Value = record.DateOfJoining;
                        WorkSheet1.Cells[recordIndex, 18].Value = record.EmergencyName;
                        WorkSheet1.Cells[recordIndex, 19].Value = record.EmergencyContactNumber;
                        WorkSheet1.Cells[recordIndex, 20].Value = record.EmergencyRelation;
                        WorkSheet1.Cells[recordIndex, 21].Value = record.BloodGroup;
                        WorkSheet1.Cells[recordIndex, 22].Value = record.Gender;
                        WorkSheet1.Cells[recordIndex, 23].Value = record.MaritalStatus;
                        WorkSheet1.Cells[recordIndex, 24].Value = record.WorkingHour;
                        WorkSheet1.Cells[recordIndex, 25].Value = record.Rate;
                        WorkSheet1.Cells[recordIndex, 26].Value = record.RateValue;
                        WorkSheet1.Cells[recordIndex, 27].Value = record.BankName;
                        WorkSheet1.Cells[recordIndex, 28].Value = record.BankAccountNo;
                        WorkSheet1.Cells[recordIndex, 29].Value = record.BankIFSCCode;
                        WorkSheet1.Cells[recordIndex, 30].Value = record.AadharNumber;
                        WorkSheet1.Cells[recordIndex, 31].Value = record.PanNumber;
                        WorkSheet1.Cells[recordIndex, 32].Value = record.OtherProof;
                        WorkSheet1.Cells[recordIndex, 33].Value = record.IsSupervisor;
                        WorkSheet1.Cells[recordIndex, 34].Value = record.IsMobileUser;
                        WorkSheet1.Cells[recordIndex, 35].Value = record.IsWebUser;
                        WorkSheet1.Cells[recordIndex, 36].Value = record.IsActive;
                        WorkSheet1.Cells[recordIndex, 37].Value = record.ValidationMessage;

                        recordIndex += 1;
                    }

                    WorkSheet1.Columns.AutoFit();

                    excelInvalidData.SaveAs(msInvalidDataFile);
                    msInvalidDataFile.Position = 0;
                    result = msInvalidDataFile.ToArray();
                }
            }

            return result;
        }

        #endregion
    }
}
