using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models
{
    public record FieldItemTableEntity : ITableEntity
    {
        public string RowKey { get; set; } // FieldId

        public string PartitionKey { get; set; } // Item

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string FieldValue { get; set; }

        public string FieldType => RowKey == "f16b9161-e263-4c81-b160-23d6ee6ade93" ? "Url" : "DestinationUrl";

        public bool IsSitecoreItemDestination => Guid.TryParse(FieldValue, out _);

        public string Created { get; set; }
    }
}
