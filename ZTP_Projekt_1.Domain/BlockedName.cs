namespace ZTP_Projekt_1.Domain
{
    public class BlockedName
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public static implicit operator BlockedName(string name)
        {
            return new BlockedName
            {
                Id = 0,
                Name = name
            };
        }
    }
}
