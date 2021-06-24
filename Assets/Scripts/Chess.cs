using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    public enum ChessType { Rook, Bishop, Unknown }

    //public IChess iChess;

    public ChessType type = ChessType.Unknown;

    public bool isPlayer;

    //public Sprite sprite;

    public static Chess Instance;
    public int xBoard = -1;
    public int yBoard = -1;

    public int index = -1;

    public Vector2 random = Vector2.zero;

    public List<Vector2> moves = new List<Vector2>();

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerShowMove()
    {
        StartCoroutine((GameManager.Instance.PlayerShowMove(this)));
    }

    public void EnemyShowMove()
    {
        StartCoroutine((GameManager.Instance.EnemyShowMove(this)));
    }

    public virtual void CheckAndAddMoveToList(Vector2 pos)
    {
        if (GridManager.Instance.PositionOnBoard(pos))
        {
            moves.Add(pos);
        }
    }

    public virtual void GetPosition()
    {

    }

    public virtual void GetAllPositionMove()
    {

    }

    public virtual void ShowChessMove()
    {
    }

    public virtual void ChessMove()
    {

    }


}
