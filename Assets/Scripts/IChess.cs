using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChess
{
    void GetAllPositionMove();

    void CheckAndAddMoveToList(Vector2 pos);

    void ShowChessMove();

    void ChessMove();

    void GetPosition();
}
