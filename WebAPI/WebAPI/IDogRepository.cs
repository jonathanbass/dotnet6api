namespace WebAPI
{
    public interface IDogRepository
    {
        Dog GetDog(string id);
        IEnumerable<Dog> GetDogs();
        string AddDog(Dog dog);
        void RemoveDog(string id);
        void UpdateDog(string id, Dog dog);
    }
}