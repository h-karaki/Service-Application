using System;
using Autofac;
using ServiceApplication.Interfaces;
using ServiceApplication.Models;
using ServiceApplication.Modules;
using System.Collections.Generic;
using RestSharp;

namespace ServiceApplication
{
    class ContainerWrapper
    {
        private static IContainer Container { get; set; }

        public void Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileInputData>().As<IReadData>();
            builder.RegisterType<CoordinateLookup>().As<IConvertAddressToCoordinate>();
            builder.RegisterType<ConsoleOutputData>().As<IDisplayData>();
            builder.RegisterType<ApiCalls>().As<IGetRequest>();
            builder.RegisterType<RestClient>().As<IRestClient>().UsingConstructor(typeof(string));
            builder.RegisterType<RestRequest>().As<IRestRequest>();

            //TODO: "Coordinates" Delegate Factory
            //http://docs.autofac.org/en/latest/advanced/delegate-factories.html

            Container = builder.Build();
        }
        
        public List<string> ReadDataFromSource(string source)
        {
            //http://autofac.readthedocs.io/en/latest/lifetime/disposal.html
            using (var scope = Container.BeginLifetimeScope())
            {
                var reader = scope.Resolve<IReadData>();
                return reader.ReadDataFromFileSource(source);
            }
        }

        public void DisplayData(List<string> data)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDisplayData>();
                writer.DisplayData(data);
            }
        }

        public Coordinate ConvertAddressToCoordinate(string addressData)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var convert = scope.Resolve<IConvertAddressToCoordinate>();
                var client = scope.Resolve<IRestClient>(new NamedParameter("baseUrl", GoogleMapApiurlBuilder.BuildUrl(addressData)));
                var request = scope.Resolve<IRestRequest>();
                var api = scope.Resolve<IGetRequest>();

                try
                {
                    return convert.ConvertAddressToCoordinate(addressData, api.GetRequest(client, request));
                }
                catch (Exception e) //TODO: More elaboreate Exception handling.
                {
                    Console.WriteLine("Error: MyContainer CODE:X2");
                    Console.WriteLine("2 possible reasons for the error.");
                    Console.WriteLine("Either Google Map's servers aren't responding, or your internet is down.");
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

    }
}
