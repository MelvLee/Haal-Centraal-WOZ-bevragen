namespace Woz.BevragenMock.Generated;

[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.20.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v13.0.0.0))")]
[Microsoft.AspNetCore.Mvc.Route("/lvwoz-eto/huidigebevragingen")]

public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    /// <summary>
    /// Zoek WOZ-objecten
    /// </summary>
    /// <remarks>
    /// Zoek WOZ-objecten op eigenaar of adres. Het resultaat zijn de actuele gegevens van de gevonden objecten.
    /// </remarks>
    /// <param name="rsin">Zoek WOZ-objecten in eigendom van een bij het Handelsregister ingeschreven niet-natuurlijk persoon</param>
    /// <param name="kvkNummer">Zoek WOZ-objecten in eigendom van een bij het Handelsregister ingeschreven maatschappelijke activiteit of een van de daaronder vallende ondernemingen en vestigingen</param>
    /// <param name="adresseerbaarObjectIdentificatie">Zoek op de BAG identificatie van een adresseerbaar object (verblijfsobject, standplaats of ligplaats) waar het WOZ-object aan verbonden is</param>
    /// <param name="nummeraanduidingIdentificatie">Zoek op de BAG identificatie van een nummeraanduiding (adres) waarmee het WOZ-object wordt aangeduid</param>
    /// <param name="postcode">Zoek WOZ-objecten met postcode, in combinatie met huisnummer en eventueel met huisletter en/of huisnummertoevoeging</param>
    /// <param name="huisnummer">Zoek WOZ-objecten met huisnummer, in combinatie met postcode en eventueel met huisletter en/of huisnummertoevoeging"</param>
    /// <param name="huisnummertoevoeging">Zoek met een huisnummertoevoeging, in combinatie met postcode en huisnummer en eventueel huisletter.
    /// <br/>Dit is een toevoeging aan een huisnummer of een combinatie van huisnummer en huisletter.
    /// <br/>Bijvoorbeeld bij Belgiëlaan 1 A3 is 1 het huisnummer, A de huisletter en 3 de huisnummertoevoeging</param>
    /// <param name="huisletter">Zoek met een huisletter, in combinatie met postcode en huisnummer en eventueel huisnummertoevoeging.
    /// <br/>Dit is een toevoeging aan een huisnummer en huisnummertoevoeging.
    /// <br/>Bijvoorbeeld bij Belgiëlaan 1 A3 is 1 het huisnummer, A de huisletter en 3 de huisnummertoevoeging</param>
    /// <param name="fields">Hiermee kun je de inhoud van de resource naar behoefte aanpassen door een door komma's gescheiden lijst van property namen op te geven. Bij opgave van niet-bestaande properties wordt een 400 Bad Request teruggegeven. Wanneer de fields parameter niet is opgegeven, worden alle properties met een waarde teruggegeven. Zie [functionele specificaties](https://github.com/VNG-Realisatie/Haal-Centraal-common/blob/v1.2.0/features/fields.feature)</param>
    /// <param name="page">Pagina nummer</param>
    /// <returns>OK</returns>
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("wozobjecten")]
    public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<WozObjectHalCollectie>> ZoekActueleWozobjecten(ZoekFilter zoekFilter);
    //public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<WozObjectHalCollectie>> ZoekActueleWozobjecten([Microsoft.AspNetCore.Mvc.FromQuery] string rsin, [Microsoft.AspNetCore.Mvc.FromQuery] string kvkNummer, [Microsoft.AspNetCore.Mvc.FromQuery] string adresseerbaarObjectIdentificatie, [Microsoft.AspNetCore.Mvc.FromQuery] string nummeraanduidingIdentificatie, [Microsoft.AspNetCore.Mvc.FromQuery] string postcode, [Microsoft.AspNetCore.Mvc.FromQuery] int? huisnummer, [Microsoft.AspNetCore.Mvc.FromQuery] string huisnummertoevoeging, [Microsoft.AspNetCore.Mvc.FromQuery] string huisletter, [Microsoft.AspNetCore.Mvc.FromQuery] string fields, [Microsoft.AspNetCore.Mvc.FromQuery] int? page = 1, [Microsoft.AspNetCore.Mvc.FromQuery] int? pageSize = 20);

    /// <summary>
    /// Raadpleeg een WOZ-object
    /// </summary>
    /// <remarks>
    /// Raadpleeg de actuele eigenschappen van een WOZ-object
    /// </remarks>
    /// <param name="identificatie">Unieke identificatie van een WOZ-object</param>
    /// <param name="fields">Hiermee kun je de inhoud van de resource naar behoefte aanpassen door een door komma's gescheiden lijst van property namen op te geven. Bij opgave van niet-bestaande properties wordt een 400 Bad Request teruggegeven. Wanneer de fields parameter niet is opgegeven, worden alle properties met een waarde teruggegeven. Zie [functionele specificaties](https://github.com/VNG-Realisatie/Haal-Centraal-common/blob/v1.2.0/features/fields.feature)</param>
    /// <returns>OK</returns>
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("wozobjecten/{identificatie}")]
    public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<WozObjectHal>> RaadpleegActueelWozobject(string identificatie, [Microsoft.AspNetCore.Mvc.FromQuery] string fields);

}

