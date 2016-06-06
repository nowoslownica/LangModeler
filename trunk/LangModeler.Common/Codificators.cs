namespace Common
{
    enum Language
    {
        Unknown = 0, // Unknown language.
        Russiang = 1, // Russian language.
        English = 2, // English language.
        Polish = 3 // Polish language.
    };

    enum Cases
    {
        Nominative = 0,
        Genitive = 1,
        Partitive = 2,
        Dative = 3,
        Accusative = 4,
        Instrumental = 5,
        Prepositional = 6,
        Locative = 7,
        Vocative = 8
    }

    enum Gender
    {
        Unknown = 0,
        Masculine = 1,
        Feminine = 2,
        Neutral = 3
    }

    enum PartsOfSpeech
    {
        Noun = 0,
        Adjective = 1,
        Pronoun = 2,
        Adverb = 3,
        Verb = 4,
        Preposition = 5
    }
}