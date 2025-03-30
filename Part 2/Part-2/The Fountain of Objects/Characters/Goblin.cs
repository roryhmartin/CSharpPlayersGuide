namespace The_Fountain_of_Objects;

public class Goblin: Enemy
{
    
    public Goblin(int row, int column, Map map, int level, int health, int attack) : base(row, column, map, level, health, attack)
    {
        Name = "Goblin";
    }
    
}