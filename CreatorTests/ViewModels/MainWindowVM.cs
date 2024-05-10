using CommunityToolkit.Mvvm.ComponentModel;
using CreatorTests.Models;
using Microsoft.Extensions.Hosting;

namespace CreatorTests.ViewModels;

public partial class MainWindowVM : ObservableObject
{
    private Document document;

    [ObservableProperty]
    bool isEnabledApprovalSheetPage = false;

    [ObservableProperty]
    bool isEnabledBankControlTasksPage = false;

    public MainWindowVM()
    {

        //disciplineInformationVM.PushApprovalSheetPageHandle += PushApprovalSheetPage;
        DisciplineInformationVM.PushApprovalSheetPageHandle += PushApprovalSheetPage;
    }

    public void PushApprovalSheetPage(SectionDisciplineInformation sectionDisciplineInformation)
    {
        isEnabledApprovalSheetPage = true;
        document.SectionDisciplineInformation = sectionDisciplineInformation;
    }
}
