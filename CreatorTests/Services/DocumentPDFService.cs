using CreatorTests.Services.Interfaces;
using iText.Kernel.Pdf;
using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Win32;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font;

namespace CreatorTests.Services
{
    internal class DocumentPDFService : IDocumentService
    {
        public async Task Save()
        {
            string dest = GetChoosePath();//"DisciplineInformation.pdf";
            try
            {
                var font = PdfFontFactory.CreateFont(
                            Path.Combine(/*Directory.GetCurrentDirectory(), "Fonts", "FreeSans", "freesans.ttf"*//*AppDomain.CurrentDomain.BaseDirectory,*//* "freesans.ttf"*/
                                //TODO: Поменять
                                @"D:\MyUsers\MyDesctop\GitHub\Programming\My\CreatorTests\Fonts\FreeSans\freesans.ttf"), //Fonts\\FreeSans\\
                            PdfEncodings.IDENTITY_H); // Кодировка русского текста

                // Создание PDF документа
                PdfWriter writer = new PdfWriter(dest);
                PdfDocument pdf = new PdfDocument(writer);
                pdf.AddFont(font);

                Document document = new Document(pdf);
                document.SetFont(font);

                // Добавление текста в центр документа
                Paragraph title = new Paragraph("Информация о дисциплине").SetTextAlignment(TextAlignment.CENTER).SetFontSize(14).SetBold();
                //Paragraph title = new Paragraph("Information").SetTextAlignment(TextAlignment.CENTER).SetFontSize(30);

                document.Add(title);


                Table table = CreateTable();

                // Добавление таблицы в документ
                document.Add(table);

                document.Add(new Paragraph("Лист согласования").SetTextAlignment(TextAlignment.CENTER).SetFontSize(14));
                document.Add(new Paragraph($"Рассмотрен и одобрен на заседании кафедры {"Test"} протокол № {"Test"} от \"{ "Test" }\"").SetTextAlignment(TextAlignment.CENTER).SetFontSize(14));

                document.Add(new Paragraph("СОГЛАСОВАНО:").SetBold());

                // Создание параграфа и добавление текста с явными отступами
                Paragraph paragraph = new Paragraph()
                    .SetTextAlignment(TextAlignment.CENTER);  // Выравнивание текста по центру

                // Добавление текста с явными отступами
                paragraph.Add(new Paragraph("Должность").SetMarginRight(50));  // Установка отступа справа для "Должность"
                paragraph.Add(new Paragraph("Инициалы, фамилия").SetMarginLeft(50).SetMarginRight(50));  // Установка отступов слева и справа для "Инициалы, фамилия"
                paragraph.Add(new Paragraph("Подпись").SetMarginLeft(50));  // Установка отступа слева для "Подпись"

                // Добавление параграфа в документ
                document.Add(paragraph);

                document.Add(new Paragraph("РАЗРАБОТАНО:").SetBold());

                document.Add(new Paragraph("Банк контрольных заданий для проверки остаточных знаний и уровня сформированности компетенций:").SetTextAlignment(TextAlignment.CENTER).SetBold());

                // Закрытие документа
                document.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private Table CreateTable()
        {
            // Создание и заполнение таблицы
            Table table = new Table(new float[] { 30, 1000 })
                  .UseAllAvailableWidth()
                  .SetHorizontalAlignment(HorizontalAlignment.CENTER)
                  .SetFontSize(14);
                  /*SetFont(font)*/


            //// Добавление заголовков столбцов
            //table.AddHeaderCell("Левый столбец");
            //table.AddHeaderCell("Правый столбец");

            // Добавление данных в таблицу
            //table.AddCell("Направление");
            table.AddCell(new Cell().Add(new Paragraph("Направление").SetHorizontalAlignment(HorizontalAlignment.CENTER)))
                 /*.AddCell(new Cell().Add(new Paragraph("Номер группы")))*/;
            //table.AddCell("");
            table.AddCell("");

            table.AddCell(new Cell().Add(new Paragraph("Номер группы")).SetHorizontalAlignment(HorizontalAlignment.CENTER));
            table.AddCell("");

            table.AddCell("Дисциплина").SetHorizontalAlignment(HorizontalAlignment.CENTER);
            table.AddCell("");

            table.AddCell("Компетенции").SetHorizontalAlignment(HorizontalAlignment.CENTER);
            table.AddCell("");

            table.AddCell("Индикаторы достижения компетенции").SetHorizontalAlignment(HorizontalAlignment.CENTER);
            table.AddCell("");

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
    }
}
