using CommunityToolkit.Mvvm.ComponentModel;
using CreatorTests.Models;
using Microsoft.Extensions.Hosting;

namespace CreatorTests.ViewModels;

public partial class MainWindowVM : ObservableObject
{
    private Document document;

    [ObservableProperty]
    bool isEnabledApprovalSheetPage;

    [ObservableProperty]
    bool isEnabledBankControlTasksPage;

    [ObservableProperty]
    bool isSelectedApprovalSheetPage;
    
    [ObservableProperty]
    bool isSelectedBankControlTasksPage;

    public MainWindowVM()
    {
        DisciplineInformationVM.PushApprovalSheetPageHandle += PushApprovalSheetPage;
        ApprovalSheetVM.PushBankControlTasksPageHandle += PushBankControlTasksPage;
        document = new Document();
    }

    public void PushApprovalSheetPage(SectionDisciplineInformation sectionDisciplineInformation)
    {
        //isEnabledApprovalSheetPage = true;
        //OnPropertyChanged(nameof(isEnabledApprovalSheetPage));

        IsEnabledApprovalSheetPage = true;
        IsSelectedApprovalSheetPage = true;
        document.SectionDisciplineInformation = sectionDisciplineInformation;
    }

    private void PushBankControlTasksPage(SectionApprovalSheet sectionApprovalSheet)
    {
        IsEnabledBankControlTasksPage = true;
        IsSelectedBankControlTasksPage = true;
        document.SectionApprovalSheet = sectionApprovalSheet;
    }
}
