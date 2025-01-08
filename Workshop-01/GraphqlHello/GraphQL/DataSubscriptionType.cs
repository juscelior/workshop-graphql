using GraphqlHello.Model;
using GraphqlHello.Type;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphqlHello.GraphQL
{
    public class DataSubscriptionType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor
                .Field("updatedData")
                .Type<ChartDataType>()
                .Resolve(context => context.GetEventMessage<ChartData>())
                .Subscribe(async context =>
                {
                    var receiver = context.Service<ITopicEventReceiver>();

                    ISourceStream stream =
                        await receiver.SubscribeAsync<ChartData>("updatedData");

                    return stream;
                });
        }
    }
}
