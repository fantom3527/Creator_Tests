namespace CreatorTests.Models;

public class Question
{
    public string Name { get; set; }
    public string FirstAnswerName { get; set; }
    public string SecondAnswerName { get; set; }
    public string ThirdAnswerName { get; set; }
    public string FourthAnswerName { get; set; }
    public bool IsFirstRightAnswer { get; set; }
    public bool IsSecondRightAnswer { get; set; }
    public bool IsThirdRightAnswer { get; set; }
    public bool IsFourthRightAnswer { get; set; }
}
