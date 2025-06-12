var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("field-exporter-storage")
                    .RunAsEmulator(azurite => {
                        azurite.WithLifetime(ContainerLifetime.Persistent);
                        azurite.WithContainerName("field-exporter");
                        azurite.WithDataVolume("field-exporter-vol");
                        azurite.WithTablePort(27002);
                    })
                    .AddTables("field-exporter");

builder.AddProject<Projects.FieldExporter_UI>("field-exporter-ui", "aspire")
    .WithReference(storage)
    .WaitFor(storage);

builder.Build().Run();
