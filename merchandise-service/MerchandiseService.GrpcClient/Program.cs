using Grpc.Core;
using Grpc.Net.Client;
using MerchandiseService.Grpc;
using System;

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

try
{
    await client.AddMerchandiseItemAsync(new AddMerchandiseItemRequest() { Quantity = 1, ItemName = "item to add" });
}
catch (RpcException e)
{
    Console.WriteLine(e);
}

try
{
    await client.GetMerchAsync(new GetMerchRequest() { ItemId = 1 });
}
catch (RpcException e)
{
    Console.WriteLine(e);
}

try
{
    await client.GetMerchExtraditionInfoAsync(new GetMerchRequest() { ItemId = 2 });
}
catch (RpcException e)
{
    Console.WriteLine(e);
}