using System.Data;

namespace The_Fountain_of_Objects;

public interface IPlayer
{
    void SetPlayerLocation(int row, int column);
    string GetPlayerIcon();
    GetLocation GetPlayerLocation();
    bool IsValidMove(int row, int column);
    // void Move();
}