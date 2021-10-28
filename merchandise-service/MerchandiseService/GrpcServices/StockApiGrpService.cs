namespace MerchandiseService.Models
{
    //public class MerchandiseApiGrpService : MerchandiseApiGrpc.MerchandiseApiGrpcBase
    //{
    //    private readonly IMerchandiseService _MerchandiseService;

    //    public MerchandiseApiGrpService(IMerchandiseService MerchandiseService)
    //    {
    //        _MerchandiseService = MerchandiseService;
    //    }

    //    public override async Task<GetAllMerchandiseItemsResponse> GetAllMerchandiseItems(
    //        GetAllMerchandiseItemsRequest request,
    //        ServerCallContext context)
    //    {
    //        var MerchandiseItems = await _MerchandiseService.GetAll(context.CancellationToken);
    //        return new GetAllMerchandiseItemsResponse
    //        {
    //            Merchandises = { MerchandiseItems.Select(x => new GetAllMerchandiseItemsResponseUnit
    //            {
    //                ItemId = x.ItemId,
    //                Quantity = x.Quantity,
    //                ItemName = x.ItemName
    //            })}
    //        };
    //    }

    //    public override async Task<GetAllMerchandiseItemsWithNullsResponse> GetAllMerchandiseItemsWithNulls(Empty request, ServerCallContext context)
    //    {
    //        var MerchandiseItems = await _MerchandiseService.GetAll(context.CancellationToken);
    //        return new GetAllMerchandiseItemsWithNullsResponse
    //        {
    //            Merchandises = { MerchandiseItems.Select(x => new GetAllMerchandiseItemsWithNullsResponseUnit
    //            {
    //                ItemId = x.ItemId,
    //                Quantity = x.Quantity,
    //                ItemName = x.ItemName
    //            })}
    //        };
    //    }

    //    public override async Task<GetAllMerchandiseItemsMapResponse> GetAllMerchandiseItemsMap(Empty request, ServerCallContext context)
    //    {
    //        var MerchandiseItems = await _MerchandiseService.GetAll(context.CancellationToken);
    //        return new GetAllMerchandiseItemsMapResponse
    //        {
    //            Merchandises =
    //            {
    //                MerchandiseItems.ToDictionary(x => x.ItemId, x => new GetAllMerchandiseItemsResponseUnit
    //                {
    //                    ItemId = x.ItemId,
    //                    Quantity = x.Quantity,
    //                    ItemName = x.ItemName
    //                })
    //            }
    //        };
    //    }

    //    public override Task<Empty> AddMerchandiseItem(AddMerchandiseItemRequest request, ServerCallContext context)
    //    {
    //        throw new RpcException(
    //            new Status(StatusCode.InvalidArgument, "validation failed"),
    //            new Metadata { new Metadata.Entry("key", "our value") });
    //    }

    //    public override async Task GetAllMerchandiseItemsStreaming(
    //        GetAllMerchandiseItemsRequest request,
    //        IServerStreamWriter<GetAllMerchandiseItemsResponseUnit> responseStream,
    //        ServerCallContext context)
    //    {
    //        var MerchandiseItems = await _MerchandiseService.GetAll(context.CancellationToken);
    //        foreach (var item in MerchandiseItems)
    //        {
    //            if (context.CancellationToken.IsCancellationRequested)
    //            {
    //                break;
    //            }

    //            await responseStream.WriteAsync(new GetAllMerchandiseItemsResponseUnit
    //            {
    //                ItemId = item.ItemId,
    //                Quantity = item.Quantity,
    //                ItemName = item.ItemName
    //            });
    //        }
    //    }

    //    public override async Task<Empty> AddMerchandiseItemStreaming(IAsyncStreamReader<AddMerchandiseItemRequest> requestStream,
    //        ServerCallContext context)
    //    {
    //        while (!context.CancellationToken.IsCancellationRequested)
    //        {
    //            await requestStream.MoveNext();
    //            var currentItem = requestStream.Current;

    //            await _MerchandiseService.Add(new MerchandiseItemCreationModel
    //            {
    //                Quantity = currentItem.Quantity,
    //                ItemName = currentItem.ItemName
    //            }, context.CancellationToken);
    //        }

    //        return new Empty();
    //    }
    //}
}