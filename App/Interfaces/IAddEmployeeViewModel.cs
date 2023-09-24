namespace FabricAPP.Interfaces
{
    public interface IAddEmployeeViewModel
    {
        public Models.Employee Employee { get; set; }
        public void SetIsValueOk();
        public void AddUser();
    }
}
