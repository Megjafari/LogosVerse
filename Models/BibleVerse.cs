using LogosVerse.Helper;

namespace Logoverse.Models;


public class BibleVerse     //Definierar en klass som heter BibleVerse
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int Versenumber { get; set; }
    public string Text { get; set; }

    public BibleVerse() { }

    public BibleVerse(string book, int chapter, int verse, string text)
    {
        Book = book;
        Chapter = chapter;
        Versenumber = verse;
        Text = text;
    }

    public override string ToString()   //Override av ToString-metoden för att returnera en strängrepresentation av versen
    {
        string bookName = MenuHelper.GetBookDisplayName(Book);
        return $"{bookName} {Chapter}:{Versenumber} - {Text}";
    }

    public string GetReference()    //Metod för att få referensen till versen
    {
        string bookName = MenuHelper.GetBookDisplayName(Book);
        return $"{bookName} {Chapter}:{Versenumber}";
    }
}