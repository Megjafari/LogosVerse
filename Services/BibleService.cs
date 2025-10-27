using Logoverse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class BibleService       //Service för att hämta bibelverser från en extern API
{
    private readonly string apiKey;
    private readonly HttpClient httpClient;
    private List<BibleVerse> cachedVerses;

    public BibleService(string apiKey)  //Konstruktor som tar emot en API-nyckel
    {
        this.apiKey = apiKey;
        this.httpClient = new HttpClient(); // Skapar en HttpClient för att göra HTTP-förfrågningar
        this.cachedVerses = new List<BibleVerse>(); // Cache för att lagra hämtade verser


        httpClient.DefaultRequestHeaders.Add("api-key", this.apiKey);   // Lägger till API-nyckeln i HTTP-huvudet
    }

    public async Task<BibleVerse> GetVerseAsync(string book, int chapter, int verse)    //Asynkron metod för att hämta en specifik bibelvers
    {   
        try
        {
            
            string bibleId = "de4e12af7f28f599-01"; // NKJV Bible ID

            string url = $"https://api.scripture.api.bible/v1/bibles/{bibleId}/verses/{book}.{chapter}.{verse}";    // Bygger URL för API-förfrågan

            var response = await httpClient.GetAsync(url);  //det här betyder att vi väntar på att få ett svar från API:et

            if (response.IsSuccessStatusCode)   
            {
                var json = await response.Content.ReadAsStringAsync();  // Läser JSON-svaret som en sträng


                using JsonDocument doc = JsonDocument.Parse(json);  // Använder JsonDocument för att parsa JSON-svaret dynamiskt
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("data", out JsonElement data))  // Kollar om "data"-egenskapen finns
                {
                    if (data.TryGetProperty("content", out JsonElement content))    // Kollar om "content"-egenskapen finns
                    {
                        string htmlContent = content.GetString();   // Hämtar HTML-innehållet
                        string cleanText = CleanHtmlTags(htmlContent);  // Rensar HTML-taggar från innehållet

                        return new BibleVerse   // Skapar och returnerar en ny BibleVerse-objekt
                        {
                            Book = book,
                            Chapter = chapter,
                            Versenumber = verse,
                            Text = cleanText
                        };
                    }
                }

                return new BibleVerse   // Om innehållet inte hittas, returnera en tom vers med felmeddelande 
                {
                    Book = book,
                    Chapter = chapter,
                    Versenumber = verse,
                    Text = "Content not found in API response"
                };
            }
            else
            {
                return new BibleVerse
                {
                    Book = book,
                    Chapter = chapter,
                    Versenumber = verse,
                    Text = $"API Error: {response.StatusCode}"
                };
            }
        }
        catch (Exception ex)    // Fångar eventuella undantag och returnerar ett felmeddelande
        {
            return new BibleVerse
            {
                Book = book,
                Chapter = chapter,
                Versenumber = verse,
                Text = $"Error: {ex.Message}"
            };
        }
    }

    public async Task<List<BibleVerse>> GetChapterAsync(string book, int chapter)   //Asynkron metod för att hämta en hel kapitel från bibeln
    {
        try
        {
            string bibleId = "de4e12af7f28f599-01"; // NKJV Bible ID

            string url = $"https://api.scripture.api.bible/v1/bibles/{bibleId}/chapters/{book}.{chapter}";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var verses = new List<BibleVerse>();

                
                using JsonDocument doc = JsonDocument.Parse(json);  // Använder JsonDocument för att parsa JSON-svaret dynamiskt
                JsonElement root = doc.RootElement; // Hämta rot-elementet

                if (root.TryGetProperty("data", out JsonElement data))      // Kollar om "data"-egenskapen finns
                {
                    if (data.TryGetProperty("content", out JsonElement content))
                    {
                        string htmlContent = content.GetString();
                        string cleanText = CleanHtmlTags(htmlContent);

                        verses.Add(new BibleVerse
                        {
                            Book = book,
                            Chapter = chapter,
                            Versenumber = 1, 
                            Text = cleanText
                        });
                    }
                }

                return verses;
            }
            else
            {
                return new List<BibleVerse>
                {
                    new BibleVerse
                    {
                        Book = book,
                        Chapter = chapter,
                        Versenumber = 1,
                        Text = $"Could not fetch chapter: {response.StatusCode}"
                    }
                };
            }
        }
        catch (Exception ex)
        {
            return new List<BibleVerse>
            {
                new BibleVerse
                {
                    Book = book,
                    Chapter = chapter,
                    Versenumber = 1,
                    Text = $"Error fetching chapter: {ex.Message}"
                }
            };
        }
    }

    public BibleVerse GetRandomVerse()  
    {
        
        var fallbackVerses = new List<BibleVerse>
        {
            new BibleVerse("JHN", 3, 16, "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life."),
            new BibleVerse("PSA", 23, 1, "The Lord is my shepherd; I shall not want."),
            new BibleVerse("PHP", 4, 13, "I can do all things through Christ who strengthens me."),
            new BibleVerse("JER", 29, 11, "For I know the thoughts that I think toward you, says the Lord, thoughts of peace and not of evil, to give you a future and a hope."),
            new BibleVerse("ROM", 8, 28, "And we know that all things work together for good to those who love God, to those who are the called according to His purpose.")
        };

        Random rand = new Random();
        return fallbackVerses[rand.Next(fallbackVerses.Count)];
    }

    private string CleanHtmlTags(string html)
    {
        if (string.IsNullOrEmpty(html)) return html;

        // Remove HTML tags but keep the text content
        string result = System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", " ")
            .Replace("&nbsp;", " ")
            .Replace("&quot;", "\"")
            .Replace("&amp;", "&")
            .Replace("&#39;", "'")
            .Replace("  ", " ") // Remove double spaces
            .Replace("  ", " ") // Remove double spaces again
            .Trim();

        return result;
    }
}