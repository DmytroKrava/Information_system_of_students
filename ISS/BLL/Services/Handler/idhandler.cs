using System;
using System.Collections.Generic;
using System.Text;
using Catalog.BLL.DTO;

namespace BLL.Services.Handler
{
    class idhandler : Handler
    {
        public override void HandleRequest(ref GroupDTO groupdto)
        {
            groupdto.GroupID = new Random().Next(0, 10000);
            if (Successor != null)
            {
                Successor.HandleRequest(ref groupdto);
            }
        }
    }
}
