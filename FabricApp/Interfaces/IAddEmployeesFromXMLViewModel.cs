﻿using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabricAPP.Interfaces
{
    public interface IAddEmployeesFromXMLViewModel
    {
        public List<Models.Employee> Employees { get; set; }
        public bool ShowedInfo { get; set; }
        public void ShowInfo();
        public Task AsyncSetData(IReadOnlyList<IBrowserFile> files);
        public void Save();

        public void Delete(Models.Employee employee);

    }
}
