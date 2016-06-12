using System.Text;
using WpfApplication1;

namespace Projekt
{
    public abstract class Animal : IVisitLock
    {
        public string AnimalName { get; set; }
        public string OwnerName { get; set; }
        public int AnimalAge { get; set; }
        public string AnimalRace { get; set; }
        public string AnimalLook { get; set; }
        protected int _animalCount;
        protected int _animalCount2;
        public int  AnimalCount => _animalCount;
        public int AnimalCount2 => _animalCount2;

        protected Animal(string animalName, string ownerName, int animalAge, string animalRace, string animalLook, int animalCount, int animalCont2)
        {
            AnimalName = animalName;
            OwnerName = ownerName;
            AnimalAge = animalAge;
            AnimalRace = animalRace;
            AnimalLook = animalLook;
            _animalCount = animalCount;
            _animalCount2 = animalCont2;

        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(AnimalName);
            builder.Append(" ");
            builder.Append(OwnerName);
            builder.Append(" ");
            builder.Append(AnimalAge);
            builder.Append(" ");
            builder.Append(AnimalRace);
            return builder.ToString();
        }

        private bool _lock;
        public bool Lock => _lock;
        public void LockVisit()
        {
            _lock = true;
        }

        public void UnlockVisit()
        {
            _lock = false;
        }

        public void NewVisit()
        {
            if (!_lock)
                _animalCount += 1;
            else
                throw new LockException();
        }

        public void NewTreatment()
        {
            if (!_lock)
                _animalCount2 += 1;
            else
                throw new LockException();
        }

    }
}