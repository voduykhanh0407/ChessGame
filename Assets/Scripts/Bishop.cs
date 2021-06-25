using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chess
{
    public Bishop() : base()
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
        if (chess.type == ChessType.Bishop)
        {
            GameManager.Instance.CheckColor(chess);
            chess = chess.gameObject.AddComponent<Bishop>();
            chess.ShowChessMove(chess);

            StartCoroutine(chess.ChessMove());
        }
            
    }
    public override void EnemyShowMove(Chess chess)
    {
        if (chess.type == ChessType.Bishop)
        {
            GameManager.Instance.CheckColor(chess);
            chess = chess.gameObject.AddComponent<Bishop>();
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
            Vector2 right_up = new Vector2(xBoard + i, yBoard + i);
            Vector2 left_down = new Vector2(xBoard - i, yBoard - i);
            Vector2 right_down = new Vector2(xBoard + i, yBoard - i);
            Vector2 left_up = new Vector2(xBoard - i, yBoard + i);

            CheckAndAddMoveToList(right_up);
            CheckAndAddMoveToList(left_down);
            CheckAndAddMoveToList(right_down);
            CheckAndAddMoveToList(left_up);
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
