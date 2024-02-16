
namespace Products.Domain.Ports;

public interface IResponseTimeLogger
{
    void LogResponseTime(DateTime requestTime, TimeSpan responseTime, string resquest);
}
