using SuperMarket.Data.InMemory;
using SuperMarket.Management.ProductInterface;
using SuperMarket.Management.TranscationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Management.ProductManagement
{
    public class SellProduct : ISellProduct
    {
        private readonly IProductManagementRepository productInMemory;
        private readonly IRecordTransactions recordTransaction;

        public SellProduct(
            IProductManagementRepository _productInMemory
            , IRecordTransactions _recordTransaction)
        {
            productInMemory = _productInMemory;
            recordTransaction = _recordTransaction;
        }

        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productInMemory.GetProductById(productId);
            if (product == null) return;
            recordTransaction.Execute(cashierName, productId, qtyToSell);
            //Supprimer la quantité vendu de la quantité totale
            product.Quantity -= qtyToSell;
            productInMemory.UpdateProduct(product);
        }
    }
}
