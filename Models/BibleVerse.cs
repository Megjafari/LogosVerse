using LogosVerse.Helper;

public class BibleVerse
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int Verse { get; set; }
    public string Text { get; set; }

    public BibleVerse() { }

    public BibleVerse(string book, int chapter, int verse, string text)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        Text = text;
    }

    public override string ToString()
    {
        var book = BibleBooks.GetBookById(Book);
        string bookName = book?.Name ?? Book;
        return $"{bookName} {Chapter}:{Verse} - {Text}";
    }

    public string GetReference()
    {
        var book = BibleBooks.GetBookById(Book);
        string bookName = book?.Name ?? Book;
        return $"{bookName} {Chapter}:{Verse}";
    }
}