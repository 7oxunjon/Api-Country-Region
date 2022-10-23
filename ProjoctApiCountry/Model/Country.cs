namespace ProjoctApiCountry.Model
{
    public class Country
    {
        public int Id { get; set; }

        public string Title  { get; set; }

        public string Short_title { get; set; }

        public string Code { get; set; }

        public virtual List<Region> Regions { get; set; }
    }
}
