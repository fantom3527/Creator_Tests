using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CreatorTests.Models;

namespace CreatorTests.ViewModels;

public partial class DisciplineInformationVM : ObservableObject
{
    //TODO: Удалить
    //private readonly IDocumentService _documentService;
    private SectionDisciplineInformation _sectionDisciplineInformation;

    [ObservableProperty]
    string? selectedDirectionName;

    [ObservableProperty]
    string? selectedGroupNumber;

    [ObservableProperty]
    string? selectedDisciplineName;

    [ObservableProperty]
    string? selectedCompetencies;

    [ObservableProperty]
    string? indicatorsСompetenceAchievement;

    public static Action<SectionDisciplineInformation> PushApprovalSheetPageHandle { get; set; }

    [RelayCommand]
    private void PushNextPage()
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
    }
}
