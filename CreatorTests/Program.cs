using CreatorTests.ViewModels;
using CreatorTests.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CreatorTests;

internal class Program
{
    [STAThread]
    public static void Main()
    {
        // создаем хост приложения для удобного управления и переходами между формами
        var host = Host.CreateDefaultBuilder()
            // внедряем сервисы
            .ConfigureServices(services =>
            {

                services.AddSingleton<DisciplineInformationVM>();
                services.AddScoped<ApprovalSheetVM>();
                services.AddScoped<BankControlTasksVM>();
                services.AddSingleton<MainWindowVM>();

                services.AddSingleton<App>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<DisciplineInformationPage>();
            })
            .Build();

        // получаем сервис - объект класса App
        var app = host.Services.GetService<App>();

        // запускаем приложения
        app?.Run();
    }
}
