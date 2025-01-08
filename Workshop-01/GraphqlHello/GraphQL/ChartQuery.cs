using GraphqlHello.Helper;
using GraphqlHello.Model;
using GraphqlHello.Type;

namespace GraphqlHello.GraphQL
{
    [ExtendObjectType("Query")]
    public class ChartQuery
    {
        public ChartData GetChartData()
        {
            return DataStore.GetChartDataById(1);
        }

        public PagedChartData GetChartDataPaged(int page, int pageSize)
        {
            var allData = DataStore.GetAllChartData();
            var pagedData = allData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PagedChartData
            {
                Data = pagedData,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(allData.Count / (double)pageSize)
            };
        }
    }

    //Step 09: Create ChartQueryType class
    public class ChartQueryType : ObjectType<ChartQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<ChartQuery> descriptor)
        {
            //Step 10: Add GetBook field to ChartQueryType
            //Step 12: Set return type of GetChartData field to BookType
            descriptor
                .Field(f => f.GetChartData())
                .Type<ChartDataType>();

            descriptor
                .Field(f => f.GetChartDataPaged(default, default))
                .Argument("page", a => a.Type<NonNullType<IntType>>())
                .Argument("pageSize", a => a.Type<NonNullType<IntType>>())
                .Type<PagedChartDataType>();


        }
    }
}
