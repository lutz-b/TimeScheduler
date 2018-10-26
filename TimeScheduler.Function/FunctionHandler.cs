using System;
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
            throw new NotImplementedException();
        }
    }
}
