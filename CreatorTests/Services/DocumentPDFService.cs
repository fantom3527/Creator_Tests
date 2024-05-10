using CreatorTests.Models.Documents;
using CreatorTests.Services.Interfaces;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Win32;
using System.IO;

namespace CreatorTests.Services;

internal class DocumentPDFService : IDocumentService
{
    private DocumentAssessmentDiscipline _documentAssessmentDiscipline;

    public void Save(DocumentAssessmentDiscipline saveDocument)
    {
        _documentAssessmentDiscipline = saveDocument;

        try
        {
            var document = GetDocument();
            if(document == null)
                return;
            
            WriteSectionDisciplineInformation(document);
            WriteSectionApprovalSheet(document);
            WriteSectionBankControlTasks(document);

            document.Close();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private Document GetDocument()
    {
        string dest = GetChoosePath();
        if (dest == null || dest == string.Empty)
            return null;

        var font = PdfFontFactory.CreateFont(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "freesans.ttf"),
                PdfEncodings.IDENTITY_H);

        // Создание PDF документа
        PdfWriter writer = new PdfWriter(dest);
        PdfDocument pdf = new PdfDocument(writer);
        pdf.AddFont(font);

        Document document = new Document(pdf);
        document.SetFont(font);

        return document;
    }

    private void WriteSectionDisciplineInformation(Document document)
    {
        Paragraph title = new Paragraph("Информация о дисциплине").SetTextAlignment(TextAlignment.CENTER).SetFontSize(14).SetBold();
        document.Add(title);

        Table table = WriteTable();
        document.Add(table);
    }

    private void WriteSectionApprovalSheet(Document document)
    {
        document.Add(new Paragraph("Лист согласования").SetTextAlignment(TextAlignment.CENTER).SetFontSize(14));
        document.Add(new Paragraph($"Рассмотрен и одобрен на заседании кафедры {_documentAssessmentDiscipline.SectionApprovalSheet.DepartmentName ?? string.Empty}" +
            $" протокол № {_documentAssessmentDiscipline.SectionApprovalSheet.ProtocolNumber ?? string.Empty} от \"{_documentAssessmentDiscipline.SectionApprovalSheet.ApprovalYear ?? string.Empty}\"").SetTextAlignment(TextAlignment.CENTER).SetFontSize(14));

        document.Add(new Paragraph("СОГЛАСОВАНО:").SetBold());

        Paragraph firstParagraph = new Paragraph()
            .SetTextAlignment(TextAlignment.CENTER);

        firstParagraph.Add(new Paragraph("Должность").SetMarginRight(50));
        firstParagraph.Add(new Paragraph("Инициалы, фамилия").SetMarginLeft(50).SetMarginRight(50));
        firstParagraph.Add(new Paragraph("Подпись").SetMarginLeft(50));
        document.Add(firstParagraph);

        Paragraph secondParagraph = new Paragraph()
            .SetTextAlignment(TextAlignment.CENTER);

        secondParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.FirstPositionName ?? string.Empty).SetMarginRight(50));
        secondParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.FirstLastNameInitials ?? string.Empty).SetMarginLeft(50).SetMarginRight(50));
        secondParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.FirstSignature ?? string.Empty).SetMarginLeft(50));
        document.Add(secondParagraph);

        Paragraph thirdParagraph = new Paragraph()
            .SetTextAlignment(TextAlignment.CENTER);

        thirdParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.SecondPositionName ?? string.Empty).SetMarginRight(50));
        thirdParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.SecondLastNameInitials ?? string.Empty).SetMarginLeft(50).SetMarginRight(50));
        thirdParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.SecondSignature ?? string.Empty).SetMarginLeft(50));
        document.Add(thirdParagraph);

        document.Add(new Paragraph("РАЗРАБОТАНО:").SetBold());

        Paragraph fourthParagraph = new Paragraph()
            .SetTextAlignment(TextAlignment.CENTER);

        fourthParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.DevelopedPositionName ?? string.Empty).SetMarginRight(50));
        fourthParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.DevelopedLastNameInitials ?? string.Empty).SetMarginLeft(50).SetMarginRight(50));
        fourthParagraph.Add(new Paragraph(_documentAssessmentDiscipline.SectionApprovalSheet.DevelopedSignature ?? string.Empty).SetMarginLeft(50));
        document.Add(fourthParagraph);
    }

    private void WriteSectionBankControlTasks(Document document)
    {
        document.Add(new AreaBreak());
        document.Add(new Paragraph("Банк контрольных заданий для проверки остаточных знаний и уровня сформированности компетенций:").SetTextAlignment(TextAlignment.CENTER).SetBold());

        WriteQuestions(document);
    }

    private Table WriteTable()
    {
        Table table = new Table(new float[] { 30, 1000 })
              .UseAllAvailableWidth()
              .SetHorizontalAlignment(HorizontalAlignment.CENTER)
              .SetFontSize(14);

        table.AddCell(new Cell().Add(new Paragraph("Направление").SetHorizontalAlignment(HorizontalAlignment.CENTER)));
        table.AddCell(_documentAssessmentDiscipline.SectionDisciplineInformation.DirectionName ?? string.Empty).SetHorizontalAlignment(HorizontalAlignment.LEFT);

        table.AddCell(new Paragraph("Номер группы").SetHorizontalAlignment(HorizontalAlignment.CENTER));
        table.AddCell(_documentAssessmentDiscipline.SectionDisciplineInformation.GroupNumber ?? string.Empty);

        table.AddCell("Дисциплина").SetHorizontalAlignment(HorizontalAlignment.CENTER);
        table.AddCell(_documentAssessmentDiscipline.SectionDisciplineInformation.DisciplineName ?? string.Empty);

        table.AddCell("Компетенции").SetHorizontalAlignment(HorizontalAlignment.CENTER);
        table.AddCell(_documentAssessmentDiscipline.SectionDisciplineInformation.Competencies ?? string.Empty);

        table.AddCell("Индикаторы достижения компетенции").SetHorizontalAlignment(HorizontalAlignment.CENTER);
        table.AddCell(_documentAssessmentDiscipline.SectionDisciplineInformation.IndicatorsСompetenceAchievement ?? string.Empty);

        return table;
    }

    private string GetChoosePath()
    {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.Filter = "PDF files|*.pdf|All files|*.*";
        saveFileDialog1.Title = "Save PDF File";
        saveFileDialog1.ShowDialog();

        return saveFileDialog1.FileName;
    }

    private void WriteQuestions(Document document)
    {
        int i = 0;
        foreach(var qustion in _documentAssessmentDiscipline.SectionBankControlTasks.QuestionList)
        {
            document.Add(new Paragraph($"{++i} {qustion.Name ?? string.Empty}").SetHorizontalAlignment(HorizontalAlignment.CENTER));

            // Создание списка с нумерацией точками
            List list = new List()
                .SetSymbolIndent(12) // Отступ перед точкой
                .SetListSymbol("\u2022"); // Этот символ представляет точку

            list.Add(new ListItem(qustion.FirstAnswerName ?? string.Empty));
            list.Add(new ListItem(qustion.SecondAnswerName ?? string.Empty));
            list.Add(new ListItem(qustion.ThirdAnswerName ?? string.Empty));
            list.Add(new ListItem(qustion.FourthAnswerName ?? string.Empty));

            document.Add(list);
        }
    }
}
