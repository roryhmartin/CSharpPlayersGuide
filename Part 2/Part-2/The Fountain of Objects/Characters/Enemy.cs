namespace The_Fountain_of_Objects;

public class Enemy
{
    private Map _map;
    private GetLocation _getLocation;

    public Enemy(int row, int column, Map map)
    {
        _getLocation = new GetLocation(row, column);
        _map = map;
    }
}