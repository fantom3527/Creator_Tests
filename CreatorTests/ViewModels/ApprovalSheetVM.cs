namespace CreatorTests.ViewModels;

internal class ApprovalSheetVM : BaseViewModel
{
    public string DepartmentName { get; set; }
    public string ProtocolNumber { get; set; }
    public int ApprovalYear { get; set; }
    public string FirstPositionName { get; set; }
    public string SecondPositionName { get; set; }
    public string FirstLastNameInitials { get; set; }
    public string SecondLastNameInitials { get; set; }
    public string FirstSignature { get; set; }
    public string SecondSignature { get; set; }
    public string DevelopedPositionName { get; set; }
    public string DevelopedLastNameInitials { get; set; }
    public string DevelopedSignature { get; set; }
}
