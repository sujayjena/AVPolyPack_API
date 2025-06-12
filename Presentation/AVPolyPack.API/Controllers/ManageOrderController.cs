using AVPolyPack.API.Controllers;
using AVPolyPack.Application.Enums;
using AVPolyPack.Application.Helpers;
using AVPolyPack.Application.Interfaces;
using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;

namespace AVPolyPack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageOrderController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IManageOrderRepository _manageOrderRepository;
        private IFileManager _fileManager;

        public ManageOrderController(IManageOrderRepository manageOrderRepository, IFileManager fileManager)
        {
            _manageOrderRepository = manageOrderRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Order 

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOrder(Order_Request parameters)
        {
            int result = await _manageOrderRepository.SaveOrder(parameters);

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

                var vOrder = await _manageOrderRepository.GetOrderById(result);

                int rowIndex = 0;
                foreach (var item in parameters.orderItemList)
                {
                    //Front Side Upload
                    if (item != null && !string.IsNullOrWhiteSpace(item.FrontSideUpload_Base64))
                    {
                        var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(item.FrontSideUpload_Base64, "\\Uploads\\Order\\", item.FrontSideUploadOriginalFileName);

                        if (!string.IsNullOrWhiteSpace(vUploadFile))
                        {
                            item.FrontSideUploadFileName = vUploadFile;
                        }
                    }


                    if (vOrder != null)
                    {
                        rowIndex = rowIndex + 1;
                        if (item.Id == 0)
                        {
                            item.OrderItemNo = vOrder.OrderNumber + "." + rowIndex;
                        }
                    }

                    //Back Side Upload
                    if (item != null && !string.IsNullOrWhiteSpace(item.BackSideUpload_Base64))
                    {
                        var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(item.BackSideUpload_Base64, "\\Uploads\\Order\\", item.BackSideUploadOriginalFileName);

                        if (!string.IsNullOrWhiteSpace(vUploadFile))
                        {
                            item.BackSideUploadFileName = vUploadFile;
                        }
                    }

                    item.OrderId = result;

                    int resultOrderItem = await _manageOrderRepository.SaveOrderItem(item);
                }
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderList(Order_Search parameters)
        {
            IEnumerable<Order_Response> lstOrders = await _manageOrderRepository.GetOrderList(parameters);
            _response.Data = lstOrders.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageOrderRepository.GetOrderById(Id);
                if (vResultObj != null)
                {
                    var vOrderItem_Search = new OrderItem_Search();
                    vOrderItem_Search.OrderId = vResultObj.Id;

                    var vList = await _manageOrderRepository.GetOrderItemList(vOrderItem_Search);

                    vResultObj.orderItemList = vList.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Order Item

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOrderItem(OrderItem_Request parameters)
        {
            int result = await _manageOrderRepository.SaveOrderItem(parameters);

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
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderItemList(OrderItem_Search parameters)
        {
            IEnumerable<OrderItem_Response> lstOrders = await _manageOrderRepository.GetOrderItemList(parameters);
            _response.Data = lstOrders.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderItemById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _manageOrderRepository.GetOrderItemById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> DeleteOrderItem(int Id)
        {
            int result = await _manageOrderRepository.DeleteOrderItem(Id);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record deleted successfully";
            }

            _response.Id = result;
            return _response;
        }
        #endregion

        #region Order Item Looms

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOrderItem_Looms(OrderItem_Looms_List_Request parameters)
        {
            int result = 0;

            foreach(var sitem in parameters.OrderItem_Looms_List) 
            {
                var vOrderItem_Looms = new OrderItem_Looms_Request()
                {
                    Id = sitem.Id,
                    OrderItemId = sitem.OrderItemId,
                    LoomAssignNo = sitem.LoomAssignNo,
                    LoomId = sitem.LoomId,
                    IsCompletetd = sitem.IsCompletetd
                };

                result = await _manageOrderRepository.SaveOrderItem_Looms(vOrderItem_Looms);
            }

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
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record Submitted successfully";
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderItem_LoomsList(OrderItem_LoomsList_Search parameters)
        {
            IEnumerable<OrderItem_LoomsList_Response> lstOrders = await _manageOrderRepository.GetOrderItem_LoomsList(parameters);
            _response.Data = lstOrders.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderItem_LoomsById(OrderItem_Looms_Search parameters)
        {
            var vResultObj = await _manageOrderRepository.GetOrderItem_LoomsById(parameters);
            _response.Data = vResultObj.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> DeleteOrderItem_Looms(int Id)
        {
            int result = await _manageOrderRepository.DeleteOrderItem_Looms(Id);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record deleted successfully";
            }

            _response.Id = result;
            return _response;
        }
        #endregion

        #region Order Item Looms Roll

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOrderItem_Looms_Rolls(OrderItem_Looms_Rolls_List_Request parameters)
        {
            int result = 0;

            foreach (var sitem in parameters.OrderItem_Looms_Rolls_List)
            {
                var vOrderItem_Looms_Rolls = new OrderItem_Looms_Rolls_Request()
                {
                    Id = sitem.Id,
                    OrderItem_LoomsId = sitem.OrderItem_LoomsId,
                    RollNo = sitem.RollNo,
                    GrossWeight = sitem.GrossWeight,
                    TareWeight = sitem.TareWeight,
                    NetWeight = sitem.NetWeight,
                    StartReading = sitem.StartReading,
                    EndReading = sitem.EndReading,
                    Diff = sitem.Diff,
                    IsCompletetd = sitem.IsCompletetd
                };

                result = await _manageOrderRepository.SaveOrderItem_Looms_Rolls(vOrderItem_Looms_Rolls);
            }

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
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record Submitted successfully";
            }

            _response.Id = result;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderItem_Looms_Rolls_List(OrderItem_Looms_Rolls_List_Search parameters)
        {
            IEnumerable<OrderItem_Looms_Rolls_List_Response> lstOrders = await _manageOrderRepository.GetOrderItem_Looms_Rolls_List(parameters);
            _response.Data = lstOrders.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOrderItem_Looms_Rolls_ById(OrderItem_Looms_Rolls_Search parameters)
        {
            var vResultObj = await _manageOrderRepository.GetOrderItem_Looms_Rolls_ById(parameters);
            _response.Data = vResultObj.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> DeleteOrderItem_Looms_Rolls(int Id)
        {
            int result = await _manageOrderRepository.DeleteOrderItem_Looms_Rolls(Id);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record deleted successfully";
            }

            _response.Id = result;
            return _response;
        }
        #endregion
    }
}
