using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CreatorTests.Models.Documents;

namespace CreatorTests.ViewModels;

internal partial class ApprovalSheetVM : ObservableObject
{
    private SectionApprovalSheet _sectionApprovalSheet;

    [ObservableProperty]
    string departmentName;

    [ObservableProperty]
    string protocolNumber;

    [ObservableProperty]
    string approvalYear;

    [ObservableProperty]
    string firstPositionName;

    [ObservableProperty]
    string secondPositionName;

    [ObservableProperty]
    string firstLastNameInitials;

    [ObservableProperty]
    string secondLastNameInitials;

    [ObservableProperty]
    string firstSignature;

    [ObservableProperty]
    string secondSignature;

    [ObservableProperty]
    string developedPositionName;

    [ObservableProperty]
    string developedLastNameInitials;

    [ObservableProperty]
    string developedSignature;

    public static Action<SectionApprovalSheet> PushBankControlTasksPageHandler { get; set; }


    [RelayCommand]
    private void PushNextPage()
    {
        _sectionApprovalSheet = new SectionApprovalSheet()
        {
            DepartmentName = DepartmentName,
            ProtocolNumber = ProtocolNumber,
            ApprovalYear = ApprovalYear,
            FirstPositionName = FirstPositionName,
            SecondPositionName = SecondPositionName,
            FirstLastNameInitials = FirstLastNameInitials,
            SecondLastNameInitials = SecondLastNameInitials,
            FirstSignature = FirstSignature,
            SecondSignature = SecondSignature,
            DevelopedPositionName = DevelopedPositionName,
            DevelopedLastNameInitials = DevelopedLastNameInitials,
            DevelopedSignature = DevelopedSignature
        };

        PushBankControlTasksPageHandler(_sectionApprovalSheet);
    }
}
