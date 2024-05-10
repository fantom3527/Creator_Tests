using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CreatorTests.Models;
using CreatorTests.Models.Documents;
using System.Collections.ObjectModel;

namespace CreatorTests.ViewModels;

internal partial class BankControlTasksVM : ObservableObject
{
    private SectionBankControlTasks _sectionBankControlTasks;

    [ObservableProperty]
    string selectedСompetenceAchievementIndicator;

    [ObservableProperty]
    string questionName;

    [ObservableProperty]
    string firstAnswerName;

    [ObservableProperty]
    string secondAnswerName;

    [ObservableProperty]
    string thirdAnswerName;

    [ObservableProperty]
    string fourthAnswerName;

    [ObservableProperty]
    bool isFirstRightAnswer;

    [ObservableProperty]
    bool isSecondRightAnswer;

    [ObservableProperty]
    bool isThirdRightAnswer;

    [ObservableProperty]
    bool isFourthRightAnswer;

    public int QuestionCount
    {
        get
        {
            return QuestionList?.Count ?? 0;
        }
    }

    public ObservableCollection<Question> QuestionList { get; set; }

    public static Action<SectionBankControlTasks> SaveDocumentToHandler { get; set; }

    public BankControlTasksVM()
    {
        QuestionList = new ObservableCollection<Question>();
    }

    [RelayCommand]
    public void AddQuestions()
    {
        var question = new Question()
        {
            Name = QuestionName,
            FirstAnswerName = FirstAnswerName,
            SecondAnswerName = SecondAnswerName,
            ThirdAnswerName = ThirdAnswerName,
            FourthAnswerName = FourthAnswerName,
            IsFirstRightAnswer = IsFirstRightAnswer,
            IsSecondRightAnswer = IsSecondRightAnswer,
            IsThirdRightAnswer = IsThirdRightAnswer,
            IsFourthRightAnswer = IsFourthRightAnswer
        };

        QuestionList.Add(question);
        OnPropertyChanged(nameof(QuestionCount));
    }

    [RelayCommand]
    public void ClearQuestions()
    {
        QuestionList.Clear();
        OnPropertyChanged(nameof(QuestionCount));
    }

    [RelayCommand]
    public void SaveDocumentTo()
    {
        var _sectionBankControlTasks = new SectionBankControlTasks()
        {
            СompetenceAchievementIndicator = selectedСompetenceAchievementIndicator,
            QuestionList = QuestionList
        };

        SaveDocumentToHandler(_sectionBankControlTasks);
    }
}
