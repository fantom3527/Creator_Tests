using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CreatorTests.Models;

namespace CreatorTests.ViewModels;

public partial class DisciplineInformationVM : ObservableObject
{
    //TODO: Удалить
    //private readonly IDocumentService _documentService;
    private SectionDisciplineInformation _sectionDisciplineInformation;

    public string SelectedDirectionName { get; set; }
    public string SelectedGroupNumber { get; set; }
    public string SelectedDisciplineName { get; set; }
    public string SelectedCompetencies { get; set; }
    public string IndicatorsСompetenceAchievement { get; set; }

    public static Action<SectionDisciplineInformation> PushApprovalSheetPageHandle { get; set; }

    public DisciplineInformationVM()
    {
        //TODO: Удалить
        //_documentService = new DocumentPDFService();
    }

    [RelayCommand]
    private void WriteInDocument()
    {
        _sectionDisciplineInformation = new SectionDisciplineInformation()
        {
            DirectionName = SelectedDirectionName,
            GroupNumber = SelectedGroupNumber,
            DisciplineName = SelectedDisciplineName,
            Competencies = SelectedCompetencies,
            IndicatorsСompetenceAchievement = IndicatorsСompetenceAchievement
        };

        PushApprovalSheetPageHandle(_sectionDisciplineInformation);
        //_documentService.Save();
    }
}
