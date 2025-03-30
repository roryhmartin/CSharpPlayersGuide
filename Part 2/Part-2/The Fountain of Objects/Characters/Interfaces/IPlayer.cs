using System.Data;

namespace The_Fountain_of_Objects;

public interface IPlayer
{
    void SetPlayerLocation(int row, int column);
    string GetPlayerIcon();
    GetLocation GetPlayerLocation();
    bool IsValidMove(int row, int column);

    string GetName();

    int GetHealth();

    void AddHealth(int amount);

    int ReduceHealth(int amount);
    // void Move();
}