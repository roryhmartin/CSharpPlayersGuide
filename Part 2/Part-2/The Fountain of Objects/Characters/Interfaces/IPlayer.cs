namespace The_Fountain_of_Objects;

public interface IPlayer
{
    void SetPlayerLocation(int row, int column);
    string GetPlayerIcon();
    GetLocation GetPlayerLocation();
    bool IsValidMove();
    void Move();
}