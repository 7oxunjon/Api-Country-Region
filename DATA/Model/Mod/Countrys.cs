using ProjoctApiCountry.Model.Mod;

namespace ProjoctApiCountry.Model
{
    public class Countrys
    {
        public int Id { get; set; }

        public string Title  { get; set; }

        public string Short_title { get; set; }

        public string Code { get; set; }

        public virtual List<Regions> Regions { get; set; }
    }
}
