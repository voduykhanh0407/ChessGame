using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chess
{
    public Rook(): base()
    {
        //base.GetAllPositionMove();
        //base.GetPosition();
        //base.ShowChessMove();
        //base.ChessMove();
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

    public override void ShowChessMove()
    {
        GetAllPositionMove();
        index = Random.Range(0, moves.Count - 1);
        random = new Vector2(moves[index].x, moves[index].y);
    }

    public override void ChessMove()
    {
        Debug.Log(GameManager.kill);
        Debug.Log(random.x + " , " + random.y);
        if (GameManager.kill == 1)
        {
            transform.position = GameManager.Instance.killPos;
            GameManager.kill = -1;
            GameManager.Instance.CheckKill();
        }
        else
            transform.position = new Vector3(random.x, random.y, 0);

        GridManager.Instance.BaseColor(moves);
        moves = null;
    }
}
