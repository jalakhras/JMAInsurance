
using JMAInsurance.EntityFramwork.Events;

namespace JMAInsurance.EntityFramwork.Host
{
    public interface IHostEvents : IEventHandler
    {
        void Activated();
    }
}
