﻿using FabricAPP.Models;

namespace FabricAPP.Interfaces
{
    interface IEmployee
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int ContactNo { get; set; }
        string Email { get; set; }
        Address Address { get; set; }
    }
}