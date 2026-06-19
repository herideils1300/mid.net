using AbySalto.Mid.Domain.Data.Model;

namespace AbySalto.Mid.Application.Interfaces.Networking
{
    public interface IClient<S, R>
    {
        Task<R> SendWithResult(S model);
    }
}
