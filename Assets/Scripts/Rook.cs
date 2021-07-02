using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chess
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
            Vector2 left = new Vector2(xBoard - i, yBoard);
            Vector2 right = new Vector2(xBoard + i, yBoard);
            Vector2 up = new Vector2(xBoard, yBoard + i);
            Vector2 down = new Vector2(xBoard, yBoard - i);

            CheckAndAddMoveToList(left);
            CheckAndAddMoveToList(right);
            CheckAndAddMoveToList(up);
            CheckAndAddMoveToList(down);
        }
        CheckMove(moves);
    }
}
