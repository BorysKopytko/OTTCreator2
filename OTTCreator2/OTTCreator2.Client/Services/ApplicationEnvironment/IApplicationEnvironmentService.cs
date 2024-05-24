using OTTCreator2.Client.Services.Content;

namespace OTTCreator2.Client.Services.ApplicationEnvironment;

public interface IApplicationEnvironmentService
{
    public IContentService ContentService { get; }
}
