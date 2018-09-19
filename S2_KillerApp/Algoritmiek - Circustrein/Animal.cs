using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmiek___Circustrein
{
    class Animal
    {
        public string Name { get; }
        public int AnimalValue { get; }
        public bool IsVegetarian { get; }

        public Animal(string name, int animalValue, bool isVegetarian)
        {
            Name = name;
            AnimalValue = animalValue;
            IsVegetarian = isVegetarian;
        }
    }
}
