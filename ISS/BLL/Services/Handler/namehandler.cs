using System;
using System.Collections.Generic;
using System.Text;
using Catalog.BLL.DTO;

namespace BLL.Services.Handler
{
    class namehandler : Handler
    {
        public override void HandleRequest(ref GroupDTO groupdto)
        {
            groupdto.Name = "Group name";
            if (Successor != null)
            {
                Successor.HandleRequest(ref groupdto);
            }
        }
    }
}
