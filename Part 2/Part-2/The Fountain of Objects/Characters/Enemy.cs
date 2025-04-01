namespace The_Fountain_of_Objects;

public abstract class Enemy : Character
{

    // enemies should have a level, health, basic attack and stamina.
    // higher level enemies should have more health and special attacks.
    // attacks all need a range - Not relevant for now.
    // attacks cost stamina to use and an enemy can only attack if it has enough stamina to do the attack. 
    // if they do not have enough stamina, they will not attack.
    // is this needed for now? - No. Should probably just do what is required and move on in the book. 
    
    
    public string Name { get; protected set; } = "Enemy";
    
    public int Level { get; protected set; }
    public int Health { get; protected set; }
    public int Attack { get; protected set; }

    public bool _isEnemyDiscovered = false;

    public string enemyNotDiscoveredSymbol = " ";

    public Enemy(int row, int column, Map map, int level, int health, int attack) : base(row, column, map, "!")
    {
        Level = level;
        Health = health;
        Attack = attack; 
    }

    public virtual void AttackPlayer(IPlayer player)
    {
        Console.WriteLine($"{Name} attacks the player for {Attack} damage.");
        player.ReduceHealth(Attack);
        Console.WriteLine($"{player.GetName()} has {player.GetHealth()} health");
    }

    public virtual bool EnemyIsDiscovered()
    {
        return _isEnemyDiscovered = true;
    }

    public string GetEnemySymbol()
    {
        if (!_isEnemyDiscovered)
        {
            return enemyNotDiscoveredSymbol;
        }
        else
        {
            return GetIcon();
        }
    }
    
    public bool IsDead()
    {
        return Health <= 0;
    }

    
}