namespace AbySalto.Mid.Domain.Abstraction.Conversion;

public interface IMapper<F, T>
{
    T Map(F entity);
}
