using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color whiteColor, blackColor, moveColor, damageColor;
    public SpriteRenderer _renderer;
    public static Tile Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(bool isBlack)
    {
        _renderer.color = isBlack ? blackColor : whiteColor;
    }

    public void ChangeToPlayerColor()
    {
        _renderer.color = moveColor;

    }

    public void ChangeToEnemyColor()
    {
        _renderer.color = damageColor;
    }
}
