using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using OpenAI.Assistants;
using System.Text;

namespace ChatBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Run();
        }
        static async Task Run()
        {
            var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");
            builder.Services.AddScoped<HttpClient>();
            var kernel = builder.Build();
            while (true)
            {
                Console.WriteLine("Sual ver:");
                string input = Console.ReadLine();
                var response = await kernel.InvokePromptAsync(input);
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"Cavab : \n--------------\n{response}\n----------------");
            }
        }
    }
}
