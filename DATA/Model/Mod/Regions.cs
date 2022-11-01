namespace ProjoctApiCountry.Model.Mod
{
    public class Regions
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Short_title { get; set; }

        public string? Code { get; set; }

        public int CountryId { get; set; }

        public virtual Countrys Country { get; set; }
    }
}
