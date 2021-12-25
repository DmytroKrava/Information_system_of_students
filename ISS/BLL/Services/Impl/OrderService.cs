using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Impl
{
    public class OrderService
    {
        public void print(IRectorOrderService order)
        {
            order.show();
        }
    }
}
