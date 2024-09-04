using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer(IMapper mapper) : IConsumer<AuctionCreated>
{
  private readonly IMapper _mapper = mapper;

  public async Task Consume(ConsumeContext<AuctionCreated> context)
  {
    Console.WriteLine("--> consuming AuctionCreated: " + context.Message.Id);
    var item = _mapper.Map<Item>(context.Message);

    if (item.Model == "Foo") throw new ArgumentException("cannot sell cars with name of foo");
    await item.SaveAsync();
  }
}
