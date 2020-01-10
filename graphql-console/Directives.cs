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
            descriptor.Use<MyMiddleware>();
        }
    }

    public class MyMiddleware
    {
        private readonly FieldDelegate _next;

        public MyMiddleware(FieldDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(IDirectiveContext context)
        {
            await _next(context).ConfigureAwait(false);
        }
    }
}
