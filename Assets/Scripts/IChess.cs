using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChess
{
    public void GetAllPositionMove();

    public void CheckAndAddMoveToList(Vector2 pos);

    public void ShowChessMove();

    public void ChessMove();

    public void GetPosition();
}
