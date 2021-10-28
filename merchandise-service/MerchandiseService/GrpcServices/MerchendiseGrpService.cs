using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MerchandiseService.Models
{
    public class MerchandiseApiGrpService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseApiGrpService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<GetAllMerchandiseItemsResponse> GetAllMerchandiseItems(
            GetAllMerchandiseItemsRequest request,
            ServerCallContext context)
        {
            var merchandiseItems = await _merchandiseService.GetAll(context.CancellationToken);
            return new GetAllMerchandiseItemsResponse
            {
                Merchandises = { merchandiseItems.Select(x => new GetAllMerchandiseItemsResponseUnit
                {
                    ItemId = x.ItemId,
                    Quantity = x.Quantity,
                    ItemName = x.ItemName
                })}
            };
        }

        public override async Task<GetAllMerchandiseItemsWithNullsResponse> GetAllMerchandiseItemsWithNulls(Empty request, ServerCallContext context)
        {
            var merchandiseItems = await _merchandiseService.GetAll(context.CancellationToken);
            return new GetAllMerchandiseItemsWithNullsResponse
            {
                Merchandises = { merchandiseItems.Select(x => new GetAllMerchandiseItemsWithNullsResponseUnit
                {
                    ItemId = x.ItemId,
                    Quantity = x.Quantity,
                    ItemName = x.ItemName
                })}
            };
        }

        public override async Task<GetAllMerchandiseItemsMapResponse> GetAllMerchandiseItemsMap(Empty request, ServerCallContext context)
        {
            var merchandiseItems = await _merchandiseService.GetAll(context.CancellationToken);
            return new GetAllMerchandiseItemsMapResponse
            {
                Merchandises =
                {
                    merchandiseItems.ToDictionary(x => x.ItemId, x => new GetAllMerchandiseItemsResponseUnit
                    {
                        ItemId = x.ItemId,
                        Quantity = x.Quantity,
                        ItemName = x.ItemName
                    })
                }
            };
        }

        public override Task<Empty> AddMerchandiseItem(AddMerchandiseItemRequest request, ServerCallContext context)
        {
            throw new RpcException(
                new Status(StatusCode.InvalidArgument, "validation failed"),
                new Metadata { new Metadata.Entry("key", "our value") });
        }

        public override async Task GetAllMerchandiseItemsStreaming(
            GetAllMerchandiseItemsRequest request,
            IServerStreamWriter<GetAllMerchandiseItemsResponseUnit> responseStream,
            ServerCallContext context)
        {
            var merchandiseItems = await _merchandiseService.GetAll(context.CancellationToken);
            foreach (var item in merchandiseItems)
            {
                if (context.CancellationToken.IsCancellationRequested)
                {
                    break;
                }

                await responseStream.WriteAsync(new GetAllMerchandiseItemsResponseUnit
                {
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                    ItemName = item.ItemName
                });
            }
        }

        public override async Task<Empty> AddMerchandiseItemStreaming(IAsyncStreamReader<AddMerchandiseItemRequest> requestStream,
            ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await requestStream.MoveNext();
                var currentItem = requestStream.Current;

                await _merchandiseService.Add(new MerchandiseItemCreationModel
                {
                    Quantity = currentItem.Quantity,
                    ItemName = currentItem.ItemName
                }, context.CancellationToken);
            }

            return new Empty();
        }

        public override async Task<GetMerchResponse> GetMerch(GetMerchRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override async Task<GetMerchResponse> GetMerchExtraditionInfo(GetMerchRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}