namespace EnWord.Core.Models
{
    public class Word
    {
        public Guid Id { get; }
        public string enWriting { get; }

        public string transcription { get; }

        public string ruWriting { get; }

        public int freqRepeat { get; }

        public Word(string enWriting, string transcription, string ruWriting, int freqRepeat)
        {
            Id = Guid.NewGuid();
            this.enWriting = enWriting;
            this.transcription = transcription;
            this.ruWriting = ruWriting;
            this.freqRepeat = freqRepeat;
        }
    }
}
