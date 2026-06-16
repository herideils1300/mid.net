using AbySalto.Mid.Domain.Data.Model;

namespace AbySalto.Mid.Infrastructure.Outbound.Networking
{
    public interface IClient<T>
    {
        Task<T> SendWithResult(ParamsModel model);
    }
}
