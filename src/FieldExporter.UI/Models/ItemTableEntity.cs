using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models
{
    public record ItemTableEntity : ITableEntity
    {
        public required string RowKey { get; set; }

        public required string PartitionKey { get; set; } = "ITEM";

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public required string ItemName { get; set; }

        public required string ItemPath { get; set; }

    }
}
