using System;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenFaaS.Dotnet;

namespace TimeScheduler.Function
{
    public class FunctionHandler : BaseFunction
    {
        public FunctionHandler(IFunctionContext functionContext) 
            : base(functionContext)
        {
        }

        public override void Handle(string input)
        {
            var skillRequest = JsonConvert.DeserializeObject<SkillRequest>(input);
            SkillResponse response = null;

            //response = ResponseBuilder.Tell($"Request-Typ {requestType.Name}");
            response = ResponseBuilder.Tell("Unbekannte Anfrage.");

            Context.WriteContent(JsonConvert.SerializeObject(response, Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
