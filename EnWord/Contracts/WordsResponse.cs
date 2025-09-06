namespace EnWord.Contracts
{
    public record WordsResponse(
        Guid id,
        string enWriting,
        string transcription,
        string ruWriting,
        int freqRepeat);

    public record WordsRequest(
        string enWriting,
        string transcription,
        string ruWriting,
        int freqRepeat);
}
