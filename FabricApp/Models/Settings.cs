using FabricAPP.Interfaces;

namespace FabricAPP.Models
{
    internal class Settings : ISettings
    {
        internal static string ConnectionString { get; set; }
    }
}
