using GraphqlHello.Model;

namespace GraphqlHello.Type
{
    //Step 08: Create BookType class
    public class BookType : ObjectType<Book>
    {
        override protected void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(f => f.Title);
            descriptor.Field(f => f.Author);
        }
    }
}
