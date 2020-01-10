using System;
using System.Collections.Generic;
using System.Text;

namespace graphql_console
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
    public class CarBasic
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
    }
    public class Car: CarBasic
    {
        public double Speed { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string FuelType { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
