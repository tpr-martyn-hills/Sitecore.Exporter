using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models.Pattern
{
    public record PatternFieldItemTableEntity : ITableEntity
    {
        public string RowKey { get; set; } // FieldId

        public string PartitionKey { get; set; } // ItemId

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string FieldValue { get; set; }

        public string FieldType => RowKey == "d938cd93-3517-4509-9a68-9da430d8ec68" ? "Pattern" : (RowKey == "7bddf3f6-438f-4256-b47a-efdec89e9c8b" ? "SitecoreDestinationId" : "DestinationUrl") ;

        public bool IsSitecoreItemDestination => Guid.TryParse(FieldValue, out _);

        public string Created { get; set; }

    }
}
