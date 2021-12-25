using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.ClassesForHelp
{
    class DeansOrderToRectorsOrder : IRectorOrderService
    {
        private IDeanOrderService order;

        public DeansOrderToRectorsOrder(IDeanOrderService order_)
        {
            order = order_;
        }

        public void show()
        {
            order.print();
        }

    }
}
