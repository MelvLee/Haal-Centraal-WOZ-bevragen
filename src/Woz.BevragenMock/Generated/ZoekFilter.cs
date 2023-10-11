namespace Woz.BevragenMock.Generated
{
    public class ZoekFilter
    {
        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? Rsin { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? KvkNummer { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? AdresseerbaarObjectIdentificatie { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? NummeraanduidingIdentificatie { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? Postcode { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? Huisnummer { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? Huisnummertoevoeging { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? Huisletter { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public string? Fields { get; set; }

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public int? Page { get; set; } = 1;

        [Microsoft.AspNetCore.Mvc.FromQuery]
        public int? PageSize { get; set; } = 20;
    }
}
