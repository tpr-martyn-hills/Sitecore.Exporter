namespace FieldExporter.UI.Models.Exporter
{
    public class RedirectExportModel
    {
        public VersionInfo Versions { get; set; }
        public List<RedirectInfo> Redirects { get; set; } = [];
    }

    public class VersionInfo
    {
        public string SkybrudUmbracoRedirects { get; set; } = "13.0.8+17b095a0fb1524de8d797470d030229af912aa57";
        public string SkybrudUmbracoRedirectsImport { get; set; } = "13.0.1+fb6525648a5ac2e6e41092fe54018d2f981c99d0";
    }

    public class RedirectInfo
    {
        public string Key { get; set; } = Guid.NewGuid().ToString();
        public string RootKey { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string Url { get; set; }
        public DestinationInfo Destination { get; set; }
        public string Type { get; set; } = "permanent";
        public bool Permanent { get; set; } = true;
        public bool Forward { get; set; } = false;
    }

    public class DestinationInfo
    {
        public string Key { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string Url { get; set; }
        public string Type { get; set; } = "url";
    }
}
