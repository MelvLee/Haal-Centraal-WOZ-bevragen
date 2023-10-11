using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class PostcodeSpecification : Specification<WozObjectHal>
{
    private readonly string _postcode;

    public PostcodeSpecification(string postcode)
    {
        _postcode = postcode;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            wozObject.Aanduiding != null &&
                            wozObject.Aanduiding.Postcode == _postcode;
    }
}
