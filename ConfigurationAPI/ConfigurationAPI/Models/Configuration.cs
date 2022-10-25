namespace ConfigurationAPI.Models
{
    public class Configuration
    {
        public Guid ConfigurationId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? Version { get; set; }
        public string? Location { get; set; }
    }
}
