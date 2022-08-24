namespace DAL.Entities
{
    public class Attachment : BaseEntity
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }
    }
}
