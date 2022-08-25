namespace ScrumBoardApp.Models.Attachment
{
    public class AttachmentModel : BaseEntityModel
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }
    }
}
