namespace CreatorTests.Models.Documents;

public class DocumentAssessmentDiscipline : BaseDocument
{
    public SectionDisciplineInformation SectionDisciplineInformation { get; set; }
    public SectionApprovalSheet SectionApprovalSheet { get; set; }
    public SectionBankControlTasks SectionBankControlTasks { get; set; }
}
