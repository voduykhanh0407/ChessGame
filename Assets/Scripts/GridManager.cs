using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width, height;

    public GameObject[,] positions = new GameObject[8, 8];

    public Dictionary<Vector2, Tile> dictionary = new Dictionary<Vector2, Tile>();

    [SerializeField] private Transform _cam;

    [SerializeField] private Tile tilePrefab;

    public static GridManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GenerateGrid();
        SpawnPlayersChess();
        SpawnEnemiesChess();
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);

                Vector2 vector2 = new Vector2(x, y);

                dictionary.Add(vector2, spawnedTile);

                spawnedTile.name = $"Tile {x} {y}";

                var isBlack = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isBlack);
            }
        }

        _cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public void ShowPlayerPossibleMove(List<Vector2> moves)
    {
        foreach (var move in moves)
        {
            if (dictionary.ContainsKey(move))
            {
                dictionary[move].ChangeToPlayerColor();
            }
        }
    }

    public void BaseColor(List<Vector2> moves)
    {
        foreach (var move in moves)
        {
            if (dictionary.ContainsKey(move))
            {
                var isBlack = (move.x % 2 == 0 && move.y % 2 != 0) || (move.x % 2 != 0 && move.y % 2 == 0);
                dictionary[move].Init(isBlack);
            }
        }
    }

    public void ShowEnemyPossibleMove(List<Vector2> moves)
    {
        foreach (var move in moves)
        {
            if (dictionary.ContainsKey(move))
            {
                dictionary[move].ChangeToEnemyColor();
            }
        }
    }

    public bool PositionOnBoard(Vector2 pos)
    {
        if (pos.x < 0 || pos.y < 0 || pos.x >= positions.GetLength(0) || pos.y >= positions.GetLength(1))
            return false;
        return true;
    }

    public void SpawnPlayersChess()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");

        foreach(var player in obj)
        {
            Vector2 vector2 = new Vector2(Random.Range(0, 7), Random.Range(0, 7));
            player.transform.position = new Vector3(dictionary[vector2].transform.position.x, dictionary[vector2].transform.position.y, 0);
        }
    }

    public void SpawnEnemiesChess()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(var enemy in obj)
        {
            Vector2 vector2 = new Vector2(Random.Range(0, 7), Random.Range(0, 7));
            enemy.transform.position = new Vector3(dictionary[vector2].transform.position.x, dictionary[vector2].transform.position.y, 0);
        }
    }

    public void RandomSpawn(Chess chess)
    {
        Vector2 vector2 = new Vector2(Random.Range(0, 7), Random.Range(0, 7));
        chess.transform.position = new Vector3(dictionary[vector2].transform.position.x, dictionary[vector2].transform.position.y, 0);
    }
}