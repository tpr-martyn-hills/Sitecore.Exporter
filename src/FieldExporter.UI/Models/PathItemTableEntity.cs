using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models
{
    public record PathItemTableEntity : ITableEntity
    {
        public string RowKey { get; set; } // ItemId

        public string PartitionKey { get; set; } = "PathItem";

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string ItemName { get; set; }

        public string ItemPath { get; set; }

        public string ParentId { get; set; }
    }
}
