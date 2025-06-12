using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models
{
    public record RedirectUrlItemTableEntity : ITableEntity
    {
        public string RowKey { get; set; } // ItemId

        public string PartitionKey { get; set; } = "RedirectUrl";

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string ItemPath { get; set; }

        public string Url { get; set; }

        public string DestinationUrl { get; set; }

        public string SitecoreDestinationId { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public bool IsSitecoreItemDestination => Guid.TryParse(DestinationUrl, out _);

        public bool IsSitecoreItemIdDestination => !string.IsNullOrEmpty(SitecoreDestinationId);

        public bool RedirectGenerated { get; set; }

        public bool IsValidRedirect => RedirectGenerated && !string.IsNullOrWhiteSpace(Url) && !string.IsNullOrWhiteSpace(DestinationUrl);
    }
}
