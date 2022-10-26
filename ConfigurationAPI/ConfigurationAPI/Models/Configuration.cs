namespace ConfigurationAPI.Models
{
    public class Configuration
    {
        public Guid ConfigurationId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? ConfigurationState { get; set; }
        public DateTime? VersionedDate { get; set; }
        public int? VersionId { get; set; }
        public DateTime? VersionExpired { get; set; }
    }
}
