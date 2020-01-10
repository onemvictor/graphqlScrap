using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graphql_console
{
    public class QueryType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Directive(new MyDirectiveType()); //Omit this line, and everything runs fine

            descriptor.Field<PersonResolver>(resolver => resolver.GetPerson(default))
            .Type<PersonObjectType>();
        }
    }
}
