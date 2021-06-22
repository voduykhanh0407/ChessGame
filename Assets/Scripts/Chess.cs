using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour, IChess
{
    public enum ChessType { Rook, Bishop, Unknown }

    public IChess iChess;

    public ChessType type = ChessType.Unknown;

    public bool isPlayer;

    //public Sprite sprite;

    public static Chess Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerShowMove()
    {
        GameManager.Instance.PlayerShowMove(this);
    }

    public void EnemyShowMove()
    {
        GameManager.Instance.EnemyShowMove(this);
    }

    public virtual void GetAllPositionMove()
    {
        
    }

    public virtual void CheckAndAddMoveToList(Vector2 pos)
    {
        
    }

    public virtual void ShowChessMove()
    {
        
    }

    public virtual void ChessMove()
    {
        
    }

    public virtual void GetPosition()
    {
        
    }
}
