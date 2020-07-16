using isaraerospace.assigment.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace isaraerospace.assigment.dal.Concrete.CSV
{
    public class AssigmentCsvSerilizer
    {
        public AssigmentCsvSerilizer(string filename)
        {
            this.FileName = filename;
            LoadCsv();
        }

        public string FileName { get; }

        public List<Book> LoadCsv()
        {

            List<Book> books = new List<Book>();
            var lines = File.ReadAllLines(FileName);
            for (int i = 1; i < lines.Length; i++)
            {
                var cells = lines[i].Replace("\r", "").Split(';').ToList();

                cells = MakeProcess(cells);
                if (cells.Count < 7) continue;
                Book currentbook = new Book();
                currentbook.ID = i - 1;
                currentbook.Title = cells[0];
                currentbook.Author = cells[1];
                if (int.TryParse(cells[2], out int year)) currentbook.Year = year;
                if (decimal.TryParse(cells[3], out decimal price)) currentbook.Price = price;
                currentbook.InStock = cells[4];
                currentbook.Binding = cells[5];
                currentbook.Description = cells[6];
                books.Add(currentbook);

            }

            return books;
        }

        internal void SaveToFile(List<Book> books)
        {
            string csv = "Title;Author;Year;Price;In Stock;Binding;Description";

            foreach (Book book in books)
            {
                string currenLine = "";
                currenLine += (book.Title.Contains(";") ? "\"" + book.Title + "\"" : book.Title) + ";";
                currenLine += (book.Author.Contains(";") ? "\"" + book.Author + "\"" : book.Author) + ";";
                currenLine += book.Year.ToString() + ";";
                currenLine += book.Price + ";";
                currenLine += book.InStock + ";";
                currenLine += (book.Binding.Contains(";") ? "\"" + book.Binding + "\"" : book.Binding) + ";";
                currenLine += (book.Description.Contains(";") ? "\"" + book.Description + "\"" : book.Description) + ";";
                csv += Environment.NewLine + currenLine;
            }

            File.WriteAllText(FileName, csv);


        }

        private List<string> MakeProcess(List<string> cells)
        {
            List<string> Result = new List<string>();
            string currentCell = "";
            bool quate = false;
            foreach (string cell in cells)
            {
                if (quate)
                {
                    quate = QuateControl(Result, ref currentCell, cell);
                    continue;
                }

                quate = cell.StartsWith("\"") && !cell.StartsWith("\"\"\"");

                if (quate)
                {
                    quate = QuateControl(Result, ref currentCell, cell);
                    continue;
                }
                Result.Add(cell.ToString().Replace("\"\"\"", "\""));
                currentCell = "";

            }

            return Result;
        }

        private static bool QuateControl(List<string> Result, ref string currentCell, string cell)
        {
            bool quate;
            currentCell += cell;
            quate = cell.EndsWith("\"") && (!cell.EndsWith("\"\"\"") || cell.EndsWith("\"\"\"\""));
            quate = !quate;
            if (!quate)
            {
                currentCell = currentCell.Substring(1, currentCell.Length - 2);
                Result.Add(currentCell.ToString().Replace("\"\"\"", "\""));
                currentCell = "";
            }

            return quate;
        }
    }
}
