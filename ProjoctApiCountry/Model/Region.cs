namespace ProjoctApiCountry.Model
{
    public class Region
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Short_title { get; set; }

        public string Code { get; set; }    

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
