using OTTCreator2.Client.Models;

namespace OTTCreator2.Client.Services.FixUri;

public interface IFixUriService
{
    void FixContentItemPictureUri(IEnumerable<ContentItem> contentItems);
}
