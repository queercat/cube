namespace backend.entities.SeedData;

public class CardSeeder : ISeeder<Card>
{
    public List<Card> GenerateSeedData()
    {
        return
        [
            new Card
            {
                Id = 1,
                Name = "Princess Luna",
                OracleId = 1,
                Cubes = new List<Cube>()
            },

            new Card
            {
                Id = 2,
                Name = "Pinkie Pie",
                OracleId = 2,
                Cubes = new List<Cube>()
            }
        ];
    }
}