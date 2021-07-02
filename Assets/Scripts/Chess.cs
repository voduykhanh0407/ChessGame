using System;
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



    public virtual void Fire()
    {
        Debug.Log("this is Fire form base class");
    }



    public virtual void PlayerShowMove(Chess chess)
    {
        chess.gameObject.AddComponent<Bishop>().PlayerShowMove(chess);
        chess.gameObject.AddComponent<Rook>().PlayerShowMove(chess);
    }

    public virtual void EnemyShowMove(Chess chess)
    {
        chess.gameObject.AddComponent<Bishop>().EnemyShowMove(chess);
        chess.gameObject.AddComponent<Rook>().EnemyShowMove(chess);
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

    public virtual void ShowChessMove(Chess chess)
    {

    }

    public IEnumerator ChessMove()
    {
        yield return new WaitForSeconds(0.2f);
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
