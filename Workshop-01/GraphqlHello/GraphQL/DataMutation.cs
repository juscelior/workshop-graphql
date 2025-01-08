using GraphqlHello.Helper;
using GraphqlHello.Model;
using GraphqlHello.Type;
using HotChocolate.Subscriptions;
using static HotChocolate.ErrorCodes;

namespace GraphqlHello.GraphQL
{

    [ExtendObjectType("Mutation")]
    public class DataMutation
    {
        public async Task<ChartData> AddNewPoint(int id, int[] value, [Service] ITopicEventSender sender)
        {
            DataStore.UpdateChartDataPoints(id, value);

            var data = DataStore.GetChartDataById(id);

            await sender.SendAsync("updatedData", data);

            return data;
        }

        public async Task<bool> GenerateData(int[] ids, int rounds, [Service] ITopicEventSender sender)
        {
            for (int i = 0; i < rounds; i++)
            {
                foreach (var id in ids)
                {
                    DataStore.UpdateChartDataPointsRandon(id);

                    var data = DataStore.GetChartDataById(id);

                    await sender.SendAsync("updatedData", data);

                    Thread.Sleep(100);
                }
            }

            return true;
        }
    }


    public class DataMutationType : ObjectType<DataMutation>
    {
        protected override void Configure(
            IObjectTypeDescriptor<DataMutation> descriptor)
        {
            descriptor.Field(f => f.AddNewPoint(default, default, default))
                .Argument("id", a => a.Type<NonNullType<IntType>>())
                .Argument("value", a => a.Type<NonNullType<ListType<NonNullType<IntType>>>>())
                .Type<ChartDataType>();

            descriptor.Field(f => f.GenerateData(default, default, default))
                .Argument("ids", a => a.Type<NonNullType<ListType<NonNullType<IntType>>>>())                
                .Argument("rounds", a => a.Type<NonNullType<IntType>>())
                .Type<BooleanType>();
        }
    }
}
