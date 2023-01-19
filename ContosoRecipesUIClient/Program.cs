using RecipesApiClient;

namespace ContosoRecipesUIClient
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var recipesClient = new swaggerClient("https://localhost:7002", httpClient);

            // We do a get request with this client; similar to a get request done in browser / Swagger
            var recipes = await recipesClient.GetRecipesAsync(4);

            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Title);
            }
        }
    }
}