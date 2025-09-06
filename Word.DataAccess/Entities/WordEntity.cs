namespace EnWord.DataAccess.Entities
{
    public class WordEntity
    {
        public Guid Id { get; set; }
        public string enWriting { get; set; }

        public string transcription { get; set; }

        public string ruWriting { get; set; }

        public int freqRepeat { get; set; }

        
    }
}
