namespace WebAPI
{
    using System.Collections.Generic;

    public class DogRepository : IDogRepository
    {
        private IList<Dog> Dogs = new List<Dog>();
        public string AddDog(Dog dog)
        {
            var id = Guid.NewGuid().ToString();
            dog.Id = id;
            Dogs.Add(dog);
            return id;
        }

        public Dog GetDog(string id)
        {
            return Dogs.First(dog => dog.Id == id);
        }

        public IEnumerable<Dog> GetDogs()
        {
            return Dogs;
        }

        public void RemoveDog(string id)
        {
            var dog = Dogs.First(dog => dog.Id == id);
            Dogs.Remove(dog);
        }

        public void UpdateDog(string id, Dog dog)
        {
            var updateDog = Dogs.First(dog => dog.Id == id);
            updateDog.Age = dog.Age;
            updateDog.Weight = dog.Weight;
            updateDog.Height = dog.Height;
            updateDog.Length = dog.Length;
            updateDog.Gender = dog.Gender;
            updateDog.Owners = dog.Owners;
            updateDog.IsTrained = dog.IsTrained;
            updateDog.Name = dog.Name;
        }
    }

}
