namespace OTTCreator2.Client.Models;

public class ContentItem : UIItem
{
    public ContentCategory Category { get; set; }
    public ContentType Type { get; set; }
    public Uri Image { get; set; }
    public Uri Stream { get; set; }
}
