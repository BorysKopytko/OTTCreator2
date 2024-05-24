using OTTCreator2.Client.Models;

namespace OTTCreator2.Client.Services.Content;

public interface IContentService
{
    public Task<IEnumerable<ContentType>> GetTypesAsync();
    public Task<IEnumerable<ContentCategory>> GetCategoriesAsync(string type);
    public Task<IEnumerable<ContentItem>> GetContentItemsAsync();
    public Task<IEnumerable<ContentItem>> GetContentItemsAsync(string type, string category);
    public Task<ContentItem> GetContentItemAsync(int id);
    public Task<IEnumerable<ContentItem>> GetFavoritesAsync(string type);
    public Task <bool> SaveContentItemFavoriteAsync(int id, string token);
}
