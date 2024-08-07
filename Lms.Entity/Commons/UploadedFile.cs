namespace Lms.Entity.Commons
{
    public class UploadedFile : EditedBaseEntity
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string RelativePath { get; set; }
    }

}
