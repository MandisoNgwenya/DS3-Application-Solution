//using Application.ClientUI.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Application.ClientUI.BusinessProcess
//{
//    public class Device
//    {
//        private List<DeviceLine> lineCollection = new List<DeviceLine>();

//        ApplicationDbContext db = new ApplicationDbContext();
//        public void AddItem(DeviceModel model, int num)
//        {
//            Device line = lineCollection.Where(p => p.devices == model.Devicemodel)
//                 .FirstOrDefault().ToString();


         
//            if (line == null)
//            {
//                lineCollection.Add(
//                    new CartLine { Product = product, Quantity = quantity });
//            }
//            else
//            {
//                line.Quantity += quantity;
//            }
//        }

//        public void RemoveLine(Product product)
//        {
//            lineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
//        }

//        public decimal ComputeTotalValue()
//        {
//            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
//        }

//        public IEnumerable<CartLine> Lines
//        {
//            get { return lineCollection; }
//        }

//        public void Clear()
//        {
//            lineCollection.Clear();
//        }
//    }
//}
