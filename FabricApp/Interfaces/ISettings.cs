using FabricAPP.Models;

namespace FabricAPP.Interfaces
{
    interface ISettings
    {
        static string ConnectionString { get; set; }
    }
}
