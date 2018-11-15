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





            if (skillRequest.Request.Type == "LaunchRequest")
            {
                response = ResponseBuilder.Tell("Willkommen zum Tech-Weekly.");
            }
            else if (skillRequest.Request.Type == "IntentRequest")
            {
                var date = DateTime.Now.Date;


                var anwser = new SsmlOutputSpeech
                {
                    Ssml = $"<speak>Heute ist<say-as interpret-as=\"date\">{date:dddd}</say-as></speak>"
                    //Ssml = "<speak>Morgen ist <break> <amazon:effect name = \"whispered\"> Freitag</amazon:effect></speak>"
                    //Ssml = "<speak>Anderer Text<amazon:effect name = \"whispered\"> Text ganz leise.</amazon:effect>.Weiterer Text</speak>"
                };

                response = ResponseBuilder.Tell(anwser);
            }

            

            Context.WriteContent(JsonConvert.SerializeObject(response, Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
