
namespace Products.Domain.Ports;

public interface IResponseTimeLogger
{
    void LogResponseTime(DateTime requestTime, string resquest);
}
