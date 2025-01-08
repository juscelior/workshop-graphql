using GraphqlHello.Model;

namespace GraphqlHello.Type
{
    //Step 08: Create ChartDataType class
    public class ChartDataType : ObjectType<ChartData>
    {
        override protected void Configure(IObjectTypeDescriptor<ChartData> descriptor)
        {
            descriptor.Field(f => f.Id);
            descriptor.Field(f => f.Label);
            descriptor.Field(f => f.Points);
        }
    }
}
