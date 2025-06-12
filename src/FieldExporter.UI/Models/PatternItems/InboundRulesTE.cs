using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models.PatternItems
{
    public class InboundRulesTE : ITableEntity
    {
        public string RowKey { get; set; } // ItemId

        public string PartitionKey { get; set; } = "Item";

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string Created { get; set; }

        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemPath { get; set; }

        public string Pattern { get; set; } // d938cd93-3517-4509-9a68-9da430d8ec68

        public string DestinationItemId { get; set; } //2c3bbda8-1b48-4352-b5bf-3478104e1c5f

        public string DestinationUrlContent { get; set; }

        public string DestinationUrlSitecoreId { get; set; }

        public string DestinationUrl { get; set; }

        public bool IsSitecoreItemIdDestination => (!string.IsNullOrEmpty(DestinationUrlSitecoreId) && Guid.TryParse(DestinationUrlSitecoreId, out _));

        public bool RedirectGenerated { get; set; }

        public bool IsValidRedirect => RedirectGenerated && !string.IsNullOrWhiteSpace(Pattern) && !string.IsNullOrWhiteSpace(DestinationUrl);
    }
}
