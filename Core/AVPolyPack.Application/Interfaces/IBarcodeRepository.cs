using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IBarcodeRepository
    {
        BarcodeGenerate_Response GenerateBarcode(string value, string barcodeType);
        Task<int> SaveBarcode(Barcode_Request parameters);
        Task<Barcode_Response?> GetBarcodeById(string BarcodeNo);
    }
}
