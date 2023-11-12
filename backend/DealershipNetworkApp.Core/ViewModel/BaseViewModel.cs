namespace DealershipNetworkApp.Core.ViewModel
{
    public abstract class BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}
