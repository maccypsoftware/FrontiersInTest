namespace FrontiersInTest.Models
{
    #nullable enable
    public class BuildingModel
    {
        public int Rank { get; set; } 
        public string? Name { get; set; } 
        public string? City { get; set; } 
        public string? CompletionYear { get; set; } 
        public string? HeightMeters { get; set; }
        public string? HeightFeets { get; set; }
        public int Floors { get; set; }
        public string? Material { get; set; }
        public string? Function { get; set; }
    }
}
