namespace TeamSelectionAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Skill> Skills { get; set; } = new();
    }
}
