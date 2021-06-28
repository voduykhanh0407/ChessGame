using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chess
{
    public override void ChessMove(Chess chess)
    {
        chess.ShowChessMove();

        StartCoroutine(chess.ChessMove());
    }

    public override void GetAllPositionMove()
    {
        GetPosition();
        if (xBoard == -1 || yBoard == -1)
        {
            return;
        }
        moves = new List<Vector2>();
        for (int i = 1; i < GridManager.Instance.positions.GetLength(0); i++)
        {
            Vector2 right_up = new Vector2(xBoard + i, yBoard + i);
            Vector2 left_down = new Vector2(xBoard - i, yBoard - i);
            Vector2 right_down = new Vector2(xBoard + i, yBoard - i);
            Vector2 left_up = new Vector2(xBoard - i, yBoard + i);

            CheckAndAddMoveToList(right_up);
            CheckAndAddMoveToList(left_down);
            CheckAndAddMoveToList(right_down);
            CheckAndAddMoveToList(left_up);
        }
        CheckMove(moves);
    }
}
