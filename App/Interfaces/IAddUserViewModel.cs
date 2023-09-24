using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
    public interface IAddUserViewModel
    {
        public Models.Employee Employee { get; set; }
        public void SetIsValueOk();
        public void AddUser();
    }
}
