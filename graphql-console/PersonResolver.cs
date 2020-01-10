using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graphql_console
{
    public class PersonResolver
    {
        public Person GetPerson(IResolverContext ctx)
        {
            var person = new PersonService().GetPerson();
            if (PersonCarDetailsRequested(ctx))
            {
                var carService = new CarService();
                person.Cars = person.Cars.Select(car => carService.GetCarInfo(car.Name, car.Manufacturer));
            }
            return person;
        }

        private bool PersonCarDetailsRequested(IResolverContext resolverContext)
        {
            var namedType = resolverContext.Field.Type.NamedType();

            if (!(namedType is ObjectType<Person> personObjectType))
            {
                throw new NotSupportedException("The type structure is not supported.");
            }

            var queriedPersonFields = resolverContext.CollectFields(personObjectType);

            var carsFieldSelection = queriedPersonFields.SingleOrDefault(field => field.ResponseName == "cars");

            var carObjectType = carsFieldSelection.Field.Type.NamedType() as ObjectType;

            try
            {
                var carFields = resolverContext.CollectFields(carObjectType, carsFieldSelection.Selection.SelectionSet);
                var carClrType = typeof(Car);
                return carFields.Any(fieldSelection => fieldSelection.Field.Member.DeclaringType == carClrType);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error while collecting fields, exception {0}", ex);
                throw;
            }
        }
    }

    public class PersonService
    {
        public Person GetPerson()
        {
            return new Person
            {
                Id = 1,
                Name = "John Smith",
                Cars = new[] { new Car { Name = "Rush", Manufacturer = "Toyota" } }
            };
        }
    }

    public class CarService
    {
        public Car GetCarInfo(string carName, string manufacturer)
        {
            return new Car
            {
                Name = carName,
                Manufacturer = manufacturer,
                FuelType = "Diesel",
                Height = 1607,
                Width = 1811,
                Length = 3994,
                Speed = 150,
                SeatingCapacity = 5
            };
        }
    }
}
