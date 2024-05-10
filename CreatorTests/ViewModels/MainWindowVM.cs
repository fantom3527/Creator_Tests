using CommunityToolkit.Mvvm.ComponentModel;
using CreatorTests.Models.Documents;
using CreatorTests.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CreatorTests.ViewModels;

public partial class MainWindowVM : ObservableObject
{
    private DocumentAssessmentDiscipline documentAssessmentDiscipline;
    private readonly IDocumentService _documentService;

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
        DisciplineInformationVM.PushApprovalSheetPageHandler += PushApprovalSheetPage;
        ApprovalSheetVM.PushBankControlTasksPageHandler += PushBankControlTasksPage;
        BankControlTasksVM.SaveDocumentToHandler += SaveDocumentTo;

        documentAssessmentDiscipline = new DocumentAssessmentDiscipline();
        _documentService = App.AppHost.Services.GetRequiredService<IDocumentService>();
    }

    //TODO: Добавить Action для случаев, когда где-то будет очищено поле, тогда вкладку дизейблить
    public void PushApprovalSheetPage(SectionDisciplineInformation sectionDisciplineInformation)
    {
        IsEnabledApprovalSheetPage = true;
        IsSelectedApprovalSheetPage = true;
        documentAssessmentDiscipline.SectionDisciplineInformation = sectionDisciplineInformation;
    }

    private void PushBankControlTasksPage(SectionApprovalSheet sectionApprovalSheet)
    {
        IsEnabledBankControlTasksPage = true;
        IsSelectedBankControlTasksPage = true;
        documentAssessmentDiscipline.SectionApprovalSheet = sectionApprovalSheet;
    }

    private void SaveDocumentTo(SectionBankControlTasks sectionBankControlTasks)
    {
        documentAssessmentDiscipline.SectionBankControlTasks = sectionBankControlTasks;
        _documentService.Save(documentAssessmentDiscipline);
    }
}
