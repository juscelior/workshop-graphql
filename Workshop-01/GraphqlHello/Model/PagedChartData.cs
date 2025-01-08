using GraphqlHello.Type;

namespace GraphqlHello.Model
{
    public class PagedChartData
    {
        public List<ChartData> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

    public class PagedChartDataType : ObjectType<PagedChartData>
    {
        protected override void Configure(IObjectTypeDescriptor<PagedChartData> descriptor)
        {
            descriptor.Field(f => f.Data).Type<NonNullType<ListType<NonNullType<ChartDataType>>>>();
            descriptor.Field(f => f.CurrentPage).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.TotalPages).Type<NonNullType<IntType>>();
        }
    }
}
