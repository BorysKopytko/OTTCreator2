namespace OTTCreator2.Client.Services.Settings;

public class SettingsService : ISettingsService
{
    private const string AccessToken = "access_token";
    private const string IdToken = "id_token";
    private const string IdUseMocks = "use_mocks";
    private const string IdIdentityBase = "url_base";
    private const string IdGatewayMarketingBase = "url_marketing";
    private const string IdGatewayShoppingBase = "url_shopping";
    private const string IdUseFakeLocation = "use_fake_location";
    private const string IdLatitude = "latitude";
    private const string IdLongitude = "longitude";
    private const string IdAllowGpsLocation = "allow_gps_location";
    private readonly string AccessTokenDefault = string.Empty;
    private readonly string IdTokenDefault = string.Empty;
    private readonly bool UseMocksDefault = true;
    private readonly bool UseFakeLocationDefault = false;
    private readonly bool AllowGpsLocationDefault = false;
    private readonly double FakeLatitudeDefault = 47.604610d;
    private readonly double FakeLongitudeDefault = -122.315752d;
    private readonly string UrlIdentityDefault = GlobalSettings.Instance.BaseIdentityEndpoint;
    private readonly string UrlGatewayMarketingDefault = GlobalSettings.Instance.BaseGatewayMarketingEndpoint;
    private readonly string UrlGatewayShoppingDefault = GlobalSettings.Instance.BaseGatewayShoppingEndpoint;

    public string AuthAccessToken
    {
        get => Preferences.Get(AccessToken, AccessTokenDefault);
        set => Preferences.Set(AccessToken, value);
    }

    public string AuthIdToken
    {
        get => Preferences.Get(IdToken, IdTokenDefault);
        set => Preferences.Set(IdToken, value);
    }

    public bool UseMocks
    {
        get => Preferences.Get(IdUseMocks, UseMocksDefault);
        set => Preferences.Set(IdUseMocks, value);
    }

    public string IdentityEndpointBase
    {
        get => Preferences.Get(IdIdentityBase, UrlIdentityDefault);
        set
        {
            Preferences.Set(IdIdentityBase, value);
            GlobalSettings.Instance.BaseIdentityEndpoint = value;
        }
    }

    public string GatewayShoppingEndpointBase
    {
        get => Preferences.Get(IdGatewayShoppingBase, UrlGatewayShoppingDefault);
        set
        {
            Preferences.Set(IdGatewayShoppingBase, value);
            GlobalSettings.Instance.BaseGatewayShoppingEndpoint = value;
        }
    }

    public string GatewayMarketingEndpointBase
    {
        get => Preferences.Get(IdGatewayMarketingBase, UrlGatewayMarketingDefault);
        set
        {
            Preferences.Set(IdGatewayMarketingBase, value);
            GlobalSettings.Instance.BaseGatewayMarketingEndpoint = value;
        }
    }

    public bool UseFakeLocation
    {
        get => Preferences.Get(IdUseFakeLocation, UseFakeLocationDefault);
        set => Preferences.Set(IdUseFakeLocation, value);
    }

    public string Latitude
    {
        get => Preferences.Get(IdLatitude, FakeLatitudeDefault.ToString());
        set => Preferences.Set(IdLatitude, value);
    }

    public string Longitude
    {
        get => Preferences.Get(IdLongitude, FakeLongitudeDefault.ToString());
        set => Preferences.Set(IdLongitude, value);
    }

    public bool AllowGpsLocation
    {
        get => Preferences.Get(IdAllowGpsLocation, AllowGpsLocationDefault);
        set => Preferences.Set(IdAllowGpsLocation, value);
    }
}
