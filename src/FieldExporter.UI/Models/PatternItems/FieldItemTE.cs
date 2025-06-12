using Azure;
using Azure.Data.Tables;

namespace FieldExporter.UI.Models.PatternItems
{
    public class FieldItemTE : ITableEntity
    {
        public string RowKey { get; set; } // FieldId

        public string PartitionKey { get; set; } // ItemId

        public ETag ETag { get; set; } = ETag.All;

        public DateTimeOffset? Timestamp { get; set; }

        public string Created { get; set; }

        public string ItemId { get; set; }

        public string FieldId { get; set; }

        public string FieldValue { get; set; }

        public string FieldType => FieldId == "d938cd93-3517-4509-9a68-9da430d8ec68" ? "Pattern" : (RowKey == "2c3bbda8-1b48-4352-b5bf-3478104e1c5f" ? "DestinationItemId" : "DestinationUrlContent");

    }
}
