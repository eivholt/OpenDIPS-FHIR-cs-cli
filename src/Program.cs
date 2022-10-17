// See https://aka.ms/new-console-template for more information

global using Hl7.Fhir.Model;
global using Hl7.Fhir.Rest;
global using System.Net.Http.Headers;

const string c_fhirServer = "https://api.dips.no/fhir/"; //"https://server.fire.ly";
Console.WriteLine($"Connecting to {c_fhirServer}");

var handler = new AuthorizationMessageHandler();
var bearerToken = "[Perform Oauth 2.0 authentication, see description at https://open.dips.no/getting-started. Copy and paste access token. Currently lasts for 1 hour.]";
handler.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
handler.DipsSubscriptionKey = "[Go to open.dips.no/profile, find 'Primary key' from desired product under 'Subscriptions'.]";

var fhirClient = new FhirClient(c_fhirServer, FhirClientSettings.CreateDefault(), handler);
var patientBoundle = fhirClient.Search<Patient>(new string[]{"family=Test"});
Console.WriteLine($"Total patients: {patientBoundle.Total}, page count: {patientBoundle.Entry.Count}.");

int patientNumber = 0;
foreach(Bundle.EntryComponent entry in patientBoundle.Entry)
{
    
    System.Console.WriteLine($"- Entry {patientNumber, 2}: {entry.FullUrl}");
    
    if(entry.Resource != null)
    {
        var patient = (Patient)entry.Resource;
        Console.WriteLine($"- {patient.Id, 20} {patient.Name.FirstOrDefault()?.ToString()}");
    }

    patientNumber++;
}

//var patientBoundle = fhirClient.Read<Patient>("Patient/cdp2012466");
//Console.WriteLine($"Total patients: {patientBoundle.Name.First().Family}");

public class AuthorizationMessageHandler : HttpClientHandler
{
        public System.Net.Http.Headers.AuthenticationHeaderValue Authorization { get; set; }
        public string DipsSubscriptionKey {get; set; }
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
                if (Authorization != null)
                {
                    request.Headers.Authorization = Authorization;
                    request.Headers.Add("dips-subscription-key", DipsSubscriptionKey);
                }

                return await base.SendAsync(request, cancellationToken);
        }
}