namespace EnWord.Contracts
{
    public record WordsResponse(
        Guid id,
        string enWriting,
        string transcription,
        string ruWriting,
        int freqRepeat);
}
