namespace AbySalto.Mid.Infrastructure.Outbound.Networking
{
    public interface IClient<T>
    {
        Task<T> SendWithResult(string root, string path, params KeyValuePair<string, string>[] args);
    }
}
