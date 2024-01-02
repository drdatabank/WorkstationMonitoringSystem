using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Client.Logs;
using NLog;



var uri = "http://localhost:5000/diskReport";
Logger reportLogger = new ClientLogger().ReportLoger;

await using var connection = new HubConnectionBuilder()
    .WithUrl(uri)
    .Build();

await connection.StartAsync();

await foreach (var item in
    connection.StreamAsync<string>("Streaming"))
{
    Console.WriteLine(item);
    reportLogger.Info($"--Client disc report--" + Environment.NewLine + item);
}

