using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Chess
{
    private int xBoard = -1;
    private int yBoard = -1;

    public int index = -1;
    public Vector2 random;

    public List<Vector2> moves = new List<Vector2>();

    public override void CheckAndAddMoveToList(Vector2 pos)
    {
        if (GridManager.Instance.PositionOnBoard(pos))
        {
            moves.Add(pos);
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

    public override void ShowChessMove()
    {
        GetAllPositionMove();
        index = Random.Range(0, moves.Count - 1);
        random = new Vector2(moves[index].x, moves[index].y);
    }

    public override void ChessMove()
    {
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
