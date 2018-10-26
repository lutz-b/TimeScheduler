﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OpenFaaS.Dotnet;
using TimeScheduler.Function;

namespace TimeScheduler.Local
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var functionContext = new TestFuntionContext();
                var functionHandler = new FunctionHandler(functionContext);
                try
                {
                    var requestBody = await getRequest(context.Request.Body);
                    functionHandler.Handle(requestBody);
                    await context.Response.WriteAsync(functionContext.Content);
                }
                catch (Exception ex)
                {
                    await context.Response.WriteAsync(ex.Message);
                }
            });
        }

        private async Task<string> getRequest(Stream inputBody)
        {
            using (StreamReader reader = new StreamReader(inputBody))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
