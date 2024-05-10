using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CreatorTests.Models.Documents;

namespace CreatorTests.ViewModels;

public partial class DisciplineInformationVM : ObservableObject
{
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

    public static Action<SectionDisciplineInformation> PushApprovalSheetPageHandler { get; set; }

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

        PushApprovalSheetPageHandler(_sectionDisciplineInformation);
    }
}
