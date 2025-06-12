using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models.PatternItems
{
    public class PatternItemTE : ITableEntity
    {
        public string RowKey { get; set; } // ItemId

        public string PartitionKey { get; set; } = "Item";

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string Created { get; set; }

        public string ItemId { get; set; }

        public string ItemPath { get; set; }

        public string Pattern { get; set; }

        public string DestinationItemId { get; set; }

        public string DestinationItemPath { get; set; }

        public string DestinationUrl { get; set; }
    }
}
