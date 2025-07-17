using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture reference for John 3:16
        Reference reference = new Reference("John", 3, 16);

        // Create a Scripture object with the reference and the verse text
        Scripture scripture = new Scripture(reference, 
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life.");

        // Loop until all words are hidden or user quits
        while (true)
        {
            Console.Clear(); // Clear console for cleaner display
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nYou are great in scriputre memorizing! the end.");
                break; // End program when all words are hidden
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("You doing great, back and play agi anytime you want!.");
                break;
            }

            scripture.HideRandomWords(); // Hide some random words each iteration
        }
    }
}

// Class representing a scripture reference (book, chapter, verse)
class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Return formatted reference string
    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}

// Class representing a single word of the scripture
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Mark the word as hidden
    public void Hide()
    {
        _isHidden = true;
    }

    // Check if word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Return either hidden version (underscores) or actual word
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

// Class to manage the scripture text and reference
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split input text into words and add to list
        string[] parts = text.Split(' ');
        foreach (string word in parts)
        {
            _words.Add(new Word(word));
        }
    }

    // Hide a few random words that haven't been hidden yet
    public void HideRandomWords()
    {
        int wordsToHide = 3; // Number of words to hide per iteration
        int hiddenCount = 0;

        // Keep trying to hide until we reach the desired count
        while (hiddenCount < wordsToHide)
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }

            // Exit loop if all words are already hidden
            if (AllWordsHidden()) break;
        }
    }

    // Return the reference and current state of scripture with hidden/visible words
    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }
        return $"{_reference.ToString()}\n" + string.Join(" ", displayWords);
    }

    // Check if all words are hidden
    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
