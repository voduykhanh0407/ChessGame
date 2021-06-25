using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chess
{
    public Rook(): base()
    {
        //base.GetAllPositionMove();
        //base.GetPosition();
        //base.ShowChessMove(Instance);
        //base.ChessMove();
        //base.PlayerShowMove(Instance);
        //base.EnemyShowMove(Instance);
    }
    public override void PlayerShowMove(Chess chess)
    {
        if(chess.type == ChessType.Rook)
        {
            GameManager.Instance.CheckColor(chess);
            chess = chess.gameObject.AddComponent<Rook>();
            chess.ShowChessMove(chess);

            StartCoroutine(chess.ChessMove());
        }
    }
    public override void EnemyShowMove(Chess chess)
    {
        if (chess.type == ChessType.Rook)
        {
            GameManager.Instance.CheckColor(chess);
            chess = chess.gameObject.AddComponent<Rook>();
            chess.ShowChessMove(chess);

            StartCoroutine(chess.ChessMove());
        }
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
        GameManager.Instance.ShowColor(moves);
    }
    public override void GetPosition()
    {
        xBoard = (int)transform.position.x;
        yBoard = (int)transform.position.y;
    }

    public override void ShowChessMove(Chess chess)
    {
        GetAllPositionMove();
        index = Random.Range(0, moves.Count - 1);
        random = new Vector2(moves[index].x, moves[index].y);
    }
}
