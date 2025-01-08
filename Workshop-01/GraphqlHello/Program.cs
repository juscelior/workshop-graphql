
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
                .AddQueryType(q => q.Name("Query"))
                    .AddType<BookQuery>()
                    .AddType<ChartQuery>()
                .AddMutationType(q => q.Name("Mutation"))                
                    .AddType<DataMutation>()
                .AddSubscriptionType<DataSubscriptionType>()
                .AddInMemorySubscriptions();

            ;

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseWebSockets();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.MapControllers();

            app.UseWebSockets();

            //Step 02: Map GraphQL Server
            app.MapGraphQL();

            app.Run();
        }
    }
}
