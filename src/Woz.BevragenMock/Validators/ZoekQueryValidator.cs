using FluentValidation;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Validators;

public class ZoekQueryValidator : AbstractValidator<ZoekFilter>
{
    const string RequiredErrorMessage = "required||Parameter is verplicht.";
    const string AdresseerbaarObjectIdentificatiePattern = @"^(?!0{16})[0-9]{16}$";
    const string AdresseerbaarObjectIdentificatieErrorMessage = $"pattern||Waarde voldoet niet aan patroon {AdresseerbaarObjectIdentificatiePattern}.";
    const string KvkNummerPattern = @"^[0-9]{8}$";
    const string KvkNummerErrorMessage = $"pattern||Waarde voldoet niet aan patroon {KvkNummerPattern}.";
    const string NummeraanduidingIdentificatiePattern = @"^(?!0{16})[0-9]{16}$";
    const string NummeraanduidingIdentificatieErrorMessage = $"pattern||Waarde voldoet niet aan patroon {NummeraanduidingIdentificatiePattern}.";
    const string RsinPattern = @"^[0-9]{9}$";
    const string RsinErrorMessage = $"pattern||Waarde voldoet niet aan patroon {RsinPattern}.";

    const string HuisletterPattern = @"^[a-zA-Z]{1}$";
    const string HuisletterErrorMessage = $"pattern||Waarde voldoet niet aan patroon {HuisletterPattern}.";
    const string HuisnummertoevoegingPattern = @"^[a-zA-Z0-9 \-]{1,4}$";
    const string HuisnummertoevoegingErrorMessage = $"pattern||Waarde voldoet niet aan patroon {HuisnummertoevoegingPattern}.";
    const string NumberPattern = @"^[1-9]{1}[0-9]{0,4}$";
    const string NumberErrorMessage = "integer||Waarde is geen geldig getal.";
    const string PostcodePattern = @"^[1-9]{1}[0-9]{3}[ ]?[A-Za-z]{2}$";
    const string PostcodeErrorMessage = $"pattern||Waarde voldoet niet aan patroon {PostcodePattern}.";

    public ZoekQueryValidator(IHttpContextAccessor httpContext)
    {
        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .Must(x => x.HeeftZoekIngangParameters())
            .WithName("noRequiredParams")
            .WithMessage("Er moet minimaal één van de parameters 'rsin', 'kvkNummer', 'adresseerbaarObjectIdentificatie', 'nummeraanduidingIdentificatie' of 'postcode' met 'huisnummer' worden opgegeven")
            .When(_ => !httpContext.HttpContext.HeeftZoekIngangParameters())
            ;

        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .Must(_ => false)
            .WithName("unsupportedCombi")
            .WithMessage("Er zijn meerdere zoekingangen opgegeven. Graag 1 zoekingang gebruiken.")
            .When(_ => !httpContext.HttpContext.HeeftEénZoekIngangParameter())
            ;

        RuleFor(x => x.Rsin)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
                       .When(_ => httpContext.HttpContext!.Request.Query.ContainsKey("rsin"))
            .Matches(RsinPattern).WithMessage(RsinErrorMessage)
            ;

        RuleFor(x => x.KvkNummer)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
                       .When(_ => httpContext.HttpContext!.Request.Query.ContainsKey("kvkNummer"))
            .Matches(KvkNummerPattern).WithMessage(KvkNummerErrorMessage)
            ;

        RuleFor(x => x.AdresseerbaarObjectIdentificatie)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
                       .When(_ => httpContext.HttpContext!.Request.Query.ContainsKey("adresseerbaarObjectIdentificatie"))
            .Matches(AdresseerbaarObjectIdentificatiePattern).WithMessage(AdresseerbaarObjectIdentificatieErrorMessage)
            ;

        RuleFor(x => x.NummeraanduidingIdentificatie)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
                       .When(_ => httpContext.HttpContext!.Request.Query.ContainsKey("nummeraanduidingIdentificatie"))
            .Matches(NummeraanduidingIdentificatiePattern).WithMessage(NummeraanduidingIdentificatieErrorMessage)
            ;

        RuleFor(x => x.Postcode)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
                       .When(_ => httpContext.HttpContext!.Request.Query.ContainsKey("postcode"))
            .Matches(PostcodePattern).WithMessage(PostcodeErrorMessage);

        RuleFor(x => x.Huisnummer)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredErrorMessage)
                       .When(_ => httpContext.HttpContext!.Request.Query.ContainsKey("huisnummer"))
            .Matches(NumberPattern).WithMessage(NumberErrorMessage);

        RuleFor(x => x.Huisletter)
            .Cascade(CascadeMode.Stop)
            .Matches(HuisletterPattern).WithMessage(HuisletterErrorMessage)
            .When(x => !string.IsNullOrWhiteSpace(x.Huisletter));

        RuleFor(x => x.Huisnummertoevoeging)
            .Cascade(CascadeMode.Stop)
            .Matches(HuisnummertoevoegingPattern).WithMessage(HuisnummertoevoegingErrorMessage)
            .When(x => !string.IsNullOrWhiteSpace(x.Huisnummertoevoeging));
    }
}

public static class ZoekFilterExtensions
{
    public static bool HeeftZoekIngangParameters(this HttpContext? httpContext) =>
        httpContext != null &&
        (httpContext.Request.Query.ContainsKey("rsin") ||
         httpContext.Request.Query.ContainsKey("kvkNummer") ||
         httpContext.Request.Query.ContainsKey("adresseerbaarObjectIdentificatie") ||
         httpContext.Request.Query.ContainsKey("nummeraanduidingIdentificatie") ||
         httpContext.Request.Query.ContainsKey("postcode"));

    public static bool HeeftZoekIngangParameters(this ZoekFilter filter)
    {
        return filter.Rsin != null ||
               filter.KvkNummer != null ||
               filter.AdresseerbaarObjectIdentificatie != null ||
               filter.NummeraanduidingIdentificatie != null ||
               filter.Postcode != null;
    }

    public static bool HeeftEénZoekIngangParameter(this HttpContext? httpContext)
    {
        var count = 0;
        var query = httpContext?.Request.Query;
        if (query == null) return false;

        if (query.ContainsKey("rsin")) count++;
        if (query.ContainsKey("kvkNummer")) count++;
        if (query.ContainsKey("adresseerbaarObjectIdentificatie")) count++;
        if (query.ContainsKey("nummeraanduidingIdentificatie")) count++;
        if (query.ContainsKey("postcode")) count++;

        return count == 1;
    }
}
