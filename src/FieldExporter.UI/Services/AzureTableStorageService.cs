using Azure.Data.Tables;

namespace FieldExporter.UI.Services
{
    public class AzureTableStorageService(TableServiceClient client)
    {
        private readonly TableServiceClient _client = client;

        private async Task<TableClient> GetTableClientAsync(string tableName)
        {
            var tableClient = _client.GetTableClient(tableName);
            await tableClient.CreateIfNotExistsAsync();
            return tableClient;
        }

        public async Task AddUpdateBulkEntitiesAsync(string tableName, IEnumerable<ITableEntity> tableEntities)
        {
            var tableClient = await GetTableClientAsync(tableName);

            var partitionGroups = tableEntities.GroupBy(e => e.PartitionKey);

            const int maxBatchSize = 100; // Azure Table Storage batch size limit

            foreach (var partitionGroup in partitionGroups)
            {
                var batchGroups = partitionGroup
                    .Select((entity, index) => new { entity, index })
                    .GroupBy(x => x.index / maxBatchSize, x => x.entity);

                foreach (var batchGroup in batchGroups)
                {
                    var transactionActions = new List<TableTransactionAction>();

                    foreach (var entity in batchGroup)
                    {
                        transactionActions.Add(new TableTransactionAction(TableTransactionActionType.UpsertMerge, entity));
                    }

                    try
                    {
                        await tableClient.SubmitTransactionAsync(transactionActions);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync<T>(string tableName, string odataFilter = "") where T : class, ITableEntity, new()
        {
            var results = new List<T>();

            var tableClient = await GetTableClientAsync(tableName);

            await foreach (var entity in tableClient.QueryAsync<T>(odataFilter))
            {
                results.Add(entity);
            }

            return results;
        }

        public async Task ClearTableAsync(string tableName)
        {
            var tableClient = _client.GetTableClient(tableName);

            await tableClient.DeleteAsync();

            //await foreach (var entity in tableClient.QueryAsync<ITableEntity>())
            //{
            //    await tableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);
            //}
        }

    }
}
