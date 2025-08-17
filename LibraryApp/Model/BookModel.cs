using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int YearOfRelease { get; set; }


        public string? Validate()
        {
            if (string.IsNullOrWhiteSpace(Title) || Title.Length < 3)
                return "Title must be at least 3 characters long.";
            if (string.IsNullOrWhiteSpace(Author))
                return "Author is required.";
            if (YearOfRelease < 1800 || YearOfRelease > DateTime.Now.Year)
                return "Incorrect year.";
            return null;
        }
    }


}


//Model:
//Utwórz klasę BookModel z właściwościami:
//Id(int, auto - increment),
//Tytuł(string, wymagany, min 3 znaki),
//Autor(string, wymagany),
//Rok wydania(int, większy niż 1800 i mniejszy lub równy bieżący rok).
//Metoda Validate() powinna zwracać null jeśli dane są poprawne lub komunikat o błędzie jeśli nie.
