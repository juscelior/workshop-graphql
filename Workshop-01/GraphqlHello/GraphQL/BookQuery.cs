using GraphqlHello.Helper;
using GraphqlHello.Model;
using GraphqlHello.Type;
using System.Diagnostics.CodeAnalysis;

namespace GraphqlHello.GraphQL
{
    //Step 06: Create BookQuery class
    [ExtendObjectType("Query")]
    public class BookQuery
    {
        public Book GetBook(string title)
        {
            return BookStore.GetBook(title);
        }
    }


    //Step 09: Create BookQueryType class
    public class BookQueryType : ObjectType<BookQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<BookQuery> descriptor)
        {
            //Step 10: Add GetBook field to BookQueryType
            //Step 11: Add title argument to GetBook field
            //Step 12: Set return type of GetBook field to BookType
            descriptor
                .Field(f=> f.GetBook(default))
                .Argument("title", a => a.Type<NonNullType<StringType>>())
                .Type<BookType>();

        }
    }
}
