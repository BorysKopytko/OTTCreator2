using OTTCreator2.Client.Services.Content;

namespace OTTCreator2.Client.Services.ApplicationEnvironment;

public class ApplicationEnvironmentService : IApplicationEnvironmentService
{
    private readonly IContentService _contentService;

    public IContentService ContentService { get; private set; }

    public ApplicationEnvironmentService(
        IContentService contentService)
    {
        _contentService = contentService;
    }
}
