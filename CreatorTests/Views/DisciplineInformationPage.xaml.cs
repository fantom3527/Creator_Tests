using CreatorTests.ViewModels;
using System.Windows.Controls;

namespace CreatorTests.Views;

/// <summary>
/// Логика взаимодействия для DisciplineInformationPage.xaml
/// </summary>
public partial class DisciplineInformationPage : Page
{
    public DisciplineInformationPage(/*DisciplineInformationVM disciplineInformationVM*/)
    {
        InitializeComponent();

        //DataContext = disciplineInformationVM;
    }
}
