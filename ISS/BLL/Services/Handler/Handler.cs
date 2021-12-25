using System;
using System.Collections.Generic;
using System.Text;
using Catalog.BLL.DTO;

namespace BLL.Services.Handler
{
    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(ref GroupDTO groupdto);
    }
}
