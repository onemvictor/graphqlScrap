using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace graphql_console
{
    public class PersonObjectType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.Field(person => person.Cars).Type<ListType<CarObjectType>>();
        }
    }
    public class CarObjectType : ObjectType<Car> { }
}
