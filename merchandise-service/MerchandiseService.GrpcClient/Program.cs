using Grpc.Core;
using Grpc.Net.Client;
using MerchandiseService.Grpc;
using System;

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

// var response = await client.GetAllMerchandiseItemsAsync(new GetAllMerchandiseItemsRequest(),  ct: CancellationToken.None);
// foreach (var item in response.Merchandises)
// {
//     Console.WriteLine(($"item id {item.ItemId} - quantity {item.Quantity}"));
// }

try
{
    await client.PostMerchAsync(new PostMerchRequest() { SomeField = "it's my string!", OtherField = 33 });
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