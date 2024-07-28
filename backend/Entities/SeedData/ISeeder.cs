namespace backend.entities.SeedData;

public interface ISeeder<T>
{
    public abstract List<T> GenerateSeedData();
}