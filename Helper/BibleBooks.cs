using LogosVerse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosVerse.Helper
{
    public static class BibleBooks
    {
        public static readonly List<BibleBook> AllBooks = new List<BibleBook>
    {
        // Old Testament (39 books)
        new BibleBook { Id = "GEN", Name = "Genesis", Abbreviation = "Gen." },
        new BibleBook { Id = "EXO", Name = "Exodus", Abbreviation = "Ex." },
        new BibleBook { Id = "LEV", Name = "Leviticus", Abbreviation = "Lev." },
        new BibleBook { Id = "NUM", Name = "Numbers", Abbreviation = "Num." },
        new BibleBook { Id = "DEU", Name = "Deuteronomy", Abbreviation = "Deut." },
        new BibleBook { Id = "JOS", Name = "Joshua", Abbreviation = "Josh." },
        new BibleBook { Id = "JDG", Name = "Judges", Abbreviation = "Judg." },
        new BibleBook { Id = "RUT", Name = "Ruth", Abbreviation = "Ruth" },
        new BibleBook { Id = "1SA", Name = "1 Samuel", Abbreviation = "1 Sam." },
        new BibleBook { Id = "2SA", Name = "2 Samuel", Abbreviation = "2 Sam." },
        new BibleBook { Id = "1KI", Name = "1 Kings", Abbreviation = "1 Kings" },
        new BibleBook { Id = "2KI", Name = "2 Kings", Abbreviation = "2 Kings" },
        new BibleBook { Id = "1CH", Name = "1 Chronicles", Abbreviation = "1 Chron." },
        new BibleBook { Id = "2CH", Name = "2 Chronicles", Abbreviation = "2 Chron." },
        new BibleBook { Id = "EZR", Name = "Ezra", Abbreviation = "Ezra" },
        new BibleBook { Id = "NEH", Name = "Nehemiah", Abbreviation = "Neh." },
        new BibleBook { Id = "EST", Name = "Esther", Abbreviation = "Est." },
        new BibleBook { Id = "JOB", Name = "Job", Abbreviation = "Job" },
        new BibleBook { Id = "PSA", Name = "Psalms", Abbreviation = "Ps." },
        new BibleBook { Id = "PRO", Name = "Proverbs", Abbreviation = "Prov." },
        new BibleBook { Id = "ECC", Name = "Ecclesiastes", Abbreviation = "Eccl." },
        new BibleBook { Id = "SNG", Name = "Song of Solomon", Abbreviation = "Song" },
        new BibleBook { Id = "ISA", Name = "Isaiah", Abbreviation = "Isa." },
        new BibleBook { Id = "JER", Name = "Jeremiah", Abbreviation = "Jer." },
        new BibleBook { Id = "LAM", Name = "Lamentations", Abbreviation = "Lam." },
        new BibleBook { Id = "EZK", Name = "Ezekiel", Abbreviation = "Ezek." },
        new BibleBook { Id = "DAN", Name = "Daniel", Abbreviation = "Dan." },
        new BibleBook { Id = "HOS", Name = "Hosea", Abbreviation = "Hos." },
        new BibleBook { Id = "JOE", Name = "Joel", Abbreviation = "Joel" },
        new BibleBook { Id = "AMO", Name = "Amos", Abbreviation = "Amos" },
        new BibleBook { Id = "OBA", Name = "Obadiah", Abbreviation = "Obad." },
        new BibleBook { Id = "JON", Name = "Jonah", Abbreviation = "Jonah" },
        new BibleBook { Id = "MIC", Name = "Micah", Abbreviation = "Mic." },
        new BibleBook { Id = "NAM", Name = "Nahum", Abbreviation = "Nah." },
        new BibleBook { Id = "HAB", Name = "Habakkuk", Abbreviation = "Hab." },
        new BibleBook { Id = "ZEP", Name = "Zephaniah", Abbreviation = "Zeph." },
        new BibleBook { Id = "HAG", Name = "Haggai", Abbreviation = "Hag." },
        new BibleBook { Id = "ZEC", Name = "Zechariah", Abbreviation = "Zech." },
        new BibleBook { Id = "MAL", Name = "Malachi", Abbreviation = "Mal." },
        
        // New Testament (27 books)
        new BibleBook { Id = "MAT", Name = "Matthew", Abbreviation = "Matt." },
        new BibleBook { Id = "MAR", Name = "Mark", Abbreviation = "Mark" },
        new BibleBook { Id = "LUK", Name = "Luke", Abbreviation = "Luke" },
        new BibleBook { Id = "JHN", Name = "John", Abbreviation = "John" },
        new BibleBook { Id = "ACT", Name = "Acts", Abbreviation = "Acts" },
        new BibleBook { Id = "ROM", Name = "Romans", Abbreviation = "Rom." },
        new BibleBook { Id = "1CO", Name = "1 Corinthians", Abbreviation = "1 Cor." },
        new BibleBook { Id = "2CO", Name = "2 Corinthians", Abbreviation = "2 Cor." },
        new BibleBook { Id = "GAL", Name = "Galatians", Abbreviation = "Gal." },
        new BibleBook { Id = "EPH", Name = "Ephesians", Abbreviation = "Eph." },
        new BibleBook { Id = "PHP", Name = "Philippians", Abbreviation = "Phil." },
        new BibleBook { Id = "COL", Name = "Colossians", Abbreviation = "Col." },
        new BibleBook { Id = "1TH", Name = "1 Thessalonians", Abbreviation = "1 Thess." },
        new BibleBook { Id = "2TH", Name = "2 Thessalonians", Abbreviation = "2 Thess." },
        new BibleBook { Id = "1TI", Name = "1 Timothy", Abbreviation = "1 Tim." },
        new BibleBook { Id = "2TI", Name = "2 Timothy", Abbreviation = "2 Tim." },
        new BibleBook { Id = "TIT", Name = "Titus", Abbreviation = "Titus" },
        new BibleBook { Id = "PHM", Name = "Philemon", Abbreviation = "Philem." },
        new BibleBook { Id = "HEB", Name = "Hebrews", Abbreviation = "Heb." },
        new BibleBook { Id = "JAS", Name = "James", Abbreviation = "James" },
        new BibleBook { Id = "1PE", Name = "1 Peter", Abbreviation = "1 Pet." },
        new BibleBook { Id = "2PE", Name = "2 Peter", Abbreviation = "2 Pet." },
        new BibleBook { Id = "1JN", Name = "1 John", Abbreviation = "1 John" },
        new BibleBook { Id = "2JN", Name = "2 John", Abbreviation = "2 John" },
        new BibleBook { Id = "3JN", Name = "3 John", Abbreviation = "3 John" },
        new BibleBook { Id = "JUD", Name = "Jude", Abbreviation = "Jude" },
        new BibleBook { Id = "REV", Name = "Revelation", Abbreviation = "Rev." }
    };

        public static BibleBook GetBookById(string id) =>
            AllBooks.FirstOrDefault(b => b.Id == id);

        public static BibleBook GetBookByName(string name) =>
            AllBooks.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}