using CreatorTests.Views;
using System.Windows;

namespace CreatorTests;

internal class App : Application
{
    readonly MainWindow mainWindow;

    // через систему внедрения зависимостей получаем объект главного окна
    public App(MainWindow mainWindow)
    {
        this.mainWindow = mainWindow;
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        mainWindow.Show();
        base.OnStartup(e);
    }
}
