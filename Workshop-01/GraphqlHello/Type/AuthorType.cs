using GraphqlHello.Model;

namespace GraphqlHello.Type
{
    //Step 07: Create AuthorType class
    public class AuthorType : ObjectType<Author>
    {
        override protected void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(f => f.Name);
        }
    }
}
