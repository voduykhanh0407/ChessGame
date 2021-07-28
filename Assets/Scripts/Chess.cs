using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    public enum ChessType { Rook, Bishop, Unknown }

    public ChessType type = ChessType.Unknown;

    public bool isPlayer;

    public static Chess Instance;
    public int xBoard = -1;
    public int yBoard = -1;

    public int index = -1;

    public Vector2 random = Vector2.zero;

    public List<Vector2> moves = new List<Vector2>();

    public static Chess chessBox;

    public GameObject firePoint;

    private void Awake()
    {
        Instance = this;
    }

    public virtual void ChessMove(Chess chess)
    {

    }

    public virtual void GetAllPositionMove()
    {

    }

    public virtual void CheckAndAddMoveToList(Vector2 pos)
    {
        if (GridManager.Instance.PositionOnBoard(pos))
        {
            moves.Add(pos);
        }
    }

    public void GetPosition()
    {
        xBoard = (int)transform.position.x;
        yBoard = (int)transform.position.y;
    }

    public void ShowChessMove()
    {
        GetAllPositionMove();
        index = Random.Range(0, moves.Count - 1);
        random = new Vector2(moves[index].x, moves[index].y);
    }

    public IEnumerator ChessMove()
    {
        yield return new WaitForSeconds(0.2f);
        if (GameManager.kill == 1)
        {
            chessBox = this;
            //transform.position = GameManager.Instance.killPos;

            GameManager.Instance.Shoot(this);

            GameManager.kill = -1;
        }
        else
            transform.position = new Vector3(random.x, random.y, 0);

        GridManager.Instance.BaseColor(moves);
        moves = null;
    }

    public void CheckMove(List<Vector2> vector2)
    {
        if (isPlayer)
        {
            GridManager.Instance.ShowPlayerPossibleMove(vector2);
            GameManager.Instance.OnPlayerKill(vector2);
        }
        else
        {
            GridManager.Instance.ShowEnemyPossibleMove(vector2);
            GameManager.Instance.OnEnemyKill(vector2);
        }
    }
}
