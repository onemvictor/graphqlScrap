using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace graphql_console
{

    public class MyDirectiveType
       : DirectiveType
    {
        protected override void Configure(IDirectiveTypeDescriptor descriptor)
        {
            descriptor.Name("my");
            descriptor.Location(DirectiveLocation.Object);
            descriptor.Use(nxt => ctx => nxt(ctx));
        }
    }
}
