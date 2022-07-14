using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Serialization;
using Azure.Messaging.EventGrid;

namespace EventGridSender
{
    class Program
    {
        static void Main()
        {
                MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            EventGridPublisherClient client = new EventGridPublisherClient(
            new Uri("https://goofyegridtopicaz204.eastus-1.eventgrid.azure.net/api/events"),
                new AzureKeyCredential("EIGRwJLGYx28gxOPhpel93TDTJHtKGn5DOizSnQCKGg="));

            // Add EventGridEvents to a list to publish to the topic
            EventGridEvent egEvent =
                new EventGridEvent(
                    "ExampleEventSubject",
                    "Example.EventType",
                    "1.0",
                    "This is the event data");
              // Send the event
            await client.SendEventAsync(egEvent);
        //    var myCustomDataSerializer = new JsonObjectSerializer(
        //             new JsonSerializerOptions()
        //             {
        //                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //             });
        //     // Add EventGridEvents to a list to publish to the topic
        //     var cevent = new EventGridEvent(
        // "ExampleEventSubject",
        // "Example.EventType",
        // "1.0",
        // myCustomDataSerializer.Serialize(new CustomModel() { A = 5, B = true }));

          
        }
    }
}