using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public static SpawnProjectiles Instance;

    //public List<GameObject> vfx = new List<GameObject>();

    public GameObject effectToSpawn;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnVFX(Chess chess)
    {
        GameObject vfx;

        if (chess.firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, chess.firePoint.transform.position, Quaternion.identity);
        }
        else
        {
            //Debug.Log("No Fire Point");
        }
    }
}
