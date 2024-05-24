using OTTCreator2.Client.Exceptions;
using OTTCreator2.Client.Helpers;
using OTTCreator2.Client.Models;
using OTTCreator2.Client.Services.FixUri;
using OTTCreator2.Client.Services.Request;

namespace OTTCreator2.Client.Services.Content;

internal class ContentService: IContentService
{
    private readonly IRequestService _requestService;
    private readonly IFixUriService _fixUriService;

    private const string ApiUrlBase = "api/v2/Content";

    public ContentService(IRequestService requestService, IFixUriService fixUriService)
    {
        _requestService = requestService;
        _fixUriService = fixUriService;
    }

    public async Task<IEnumerable<ContentType>> GetTypesAsync()
    {
        var uri = UriHelper.CombineUri(GlobalSettings.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/categories");

        IEnumerable<ContentType> types = await _requestService.GetAsync<IEnumerable<ContentType>>(uri).ConfigureAwait(false);

        return types?.ToArray() ?? Enumerable.Empty<ContentType>();
    }

    public async Task<IEnumerable<ContentCategory>> GetCategoriesAsync(string type)
    {
        var uri = UriHelper.CombineUri(GlobalSettings.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{type}/categories");

        IEnumerable<ContentCategory> categories = await _requestService.GetAsync<IEnumerable<ContentCategory>>(uri).ConfigureAwait(false);

        return categories?.ToArray() ?? Enumerable.Empty<ContentCategory>();
    }

    public async Task<IEnumerable<ContentItem>> GetContentItemsAsync()
    {
        var uri = UriHelper.CombineUri(GlobalSettings.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

        IEnumerable<ContentItem> contentItems = await _requestService.GetAsync<IEnumerable<ContentItem>>(uri).ConfigureAwait(false);

        if (contentItems != null)
        {
            _fixUriService.FixContentItemPictureUri(contentItems);
            return contentItems;
        }
        else
            return Enumerable.Empty<ContentItem>();
    }

    public async Task<IEnumerable<ContentItem>> GetContentItemsAsync(string type, string category)
    {
        var uri = UriHelper.CombineUri(GlobalSettings.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{type}/{category}/contentitems");

        IEnumerable<ContentItem> contentItems = await _requestService.GetAsync<IEnumerable<ContentItem>>(uri).ConfigureAwait(false);

        return contentItems ?? Enumerable.Empty<ContentItem>();
    }

    public async Task<ContentItem> GetContentItemAsync(int id)
    {
        var uri = UriHelper.CombineUri(GlobalSettings.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/contentitems/{id}");

        ContentItem contentItem = await _requestService.GetAsync<ContentItem>(uri).ConfigureAwait(false);

        return contentItem ?? null;
    }

    public async Task<IEnumerable<ContentItem>> GetFavoritesAsync(string type)
    {
        var uri = UriHelper.CombineUri(GlobalSettings.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/{type}/contentitems/favorites");

        IEnumerable<ContentItem> contentItems = await _requestService.GetAsync<IEnumerable<ContentItem>>(uri).ConfigureAwait(false);

        return contentItems ?? Enumerable.Empty<ContentItem>();
    }

    public async Task<bool> SaveContentItemFavoriteAsync(int id, string token)
    {
        var uri = UriHelper.CombineUri(GlobalSettings.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/cancel");

        var header = "x-requestid";

        try
        {
            await _requestService.PutAsync(uri, id, token, header).ConfigureAwait(false);
        }

        catch (ExtendedHttpRequestException ex) when (ex.HttpCode == System.Net.HttpStatusCode.BadRequest)
        {
            return false;
        }

        return true;
    }
}
