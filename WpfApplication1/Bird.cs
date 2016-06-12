using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt;

namespace WpfApplication1
{
    class Bird : Animal
    {
        public Bird(string animalName, string ownerName, int animalAge, string animalRace, string animalLook, int animalCount, int animalCount2)
            : base(animalName, ownerName, animalAge, animalRace, animalLook, animalCount, animalCount2)
        {
            base.AnimalName = animalName;
            base.OwnerName = ownerName;
            base.AnimalAge = animalAge;
            base.AnimalRace = animalRace;
            base.AnimalLook = animalLook;
            base._animalCount = animalCount;
            base._animalCount2 = animalCount2;
        }
    }
}
