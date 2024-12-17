
using GraphqlHello.GraphQL;

namespace GraphqlHello
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Step 01: Add GraphQL Server
            builder.Services.AddGraphQLServer()
                //Step 13: Add Query Type
                .AddQueryType<BookQuery>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //Step 02: Map GraphQL Server
            app.MapGraphQL();

            app.Run();
        }
    }
}
