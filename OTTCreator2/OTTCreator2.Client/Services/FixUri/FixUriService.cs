using OTTCreator2.Client.Models;
using OTTCreator2.Client.Services.Settings;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace OTTCreator2.Client.Services.FixUri;

internal class FixUriService: IFixUriService
{
    private readonly ISettingsService _settingsService;

    private readonly Regex IpRegex = new(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");

    public FixUriService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public void FixContentItemPictureUri(IEnumerable<ContentItem> contentItems)
    {
        if (contentItems is null)
        {
            return;
        }

        try
        {
            if (!_settingsService.UseMocks && _settingsService.IdentityEndpointBase != GlobalSettings.DefaultEndpoint)
            {
                foreach (var contentItem in contentItems)
                {
                    MatchCollection serverResult = IpRegex.Matches(contentItem.Image.AbsoluteUri);
                    MatchCollection localResult = IpRegex.Matches(_settingsService.IdentityEndpointBase);

                    if (serverResult.Count != -1 && localResult.Count != -1)
                    {
                        var serviceIp = serverResult[0].Value;
                        var localIp = localResult[0].Value;

                        contentItem.Image = new System.Uri(contentItem.Image.AbsoluteUri.Replace(serviceIp, localIp));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
