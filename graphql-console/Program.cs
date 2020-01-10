using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Linq;

namespace graphql_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var schema = SchemaBuilder.New()
                .AddQueryType<QueryType>()
                .Create();
            var executor = schema.MakeExecutable();

            Console.WriteLine(executor.Execute(@"
            {
                person{
                    cars {
                        manufacturer
                        speed
                    }
                }
            }").ToJson());
            Console.ReadLine();
        }
    }    
}
