using Microsoft.Extensions.Configuration;
using Products.Domain.Ports;
namespace Products.Infrastructure.Adapters;

public class FileResponseTimeLogger : IResponseTimeLogger
{
    private readonly string _logFilePath;

    public FileResponseTimeLogger(IConfiguration configuration)
    {
        _logFilePath = configuration["Logging:ResponseTimeLogFile"];
    }

    public void LogResponseTime(DateTime requestTime, TimeSpan responseTime, string resquest)
    {
        try
        {
            using (StreamWriter writer = File.AppendText(_logFilePath))
            {
                writer.WriteLine($"{resquest} Request Time: {requestTime} | Response Time: {responseTime}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
        }
    }
}
