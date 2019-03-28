namespace FotoQuestGo.API.Common.Models
{
    public enum CardinalDirection
    {
        North,
        East,
        South,
        West,
        Ground
    }

    public class Foto
    {
        public int ID { get; set; }

        public int QuestID { get; set; }

        public virtual Quest Quest { get; set; }

        public CardinalDirection Direction { get; set; }

        //Decided to persist only original image
        //When foto is requested with different size, API will provide it on-the-fly
        public string Path { get; set; }
    }
}