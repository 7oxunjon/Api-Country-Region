﻿namespace ProjoctApiCountry.DTO
{
    public class RegionDTO
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Short_title { get; set; }

        public string Code { get; set; }

        public int CountryId { get; set; }
    }
}
