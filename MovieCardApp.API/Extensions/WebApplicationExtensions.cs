using MovieCardApp.API.Data;

namespace MovieCardApp.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<MovieCardAppContext>();

                try
                {
                    await SeedData.InitAsync(context);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                    throw;
                }
            }
        }
    }
}
