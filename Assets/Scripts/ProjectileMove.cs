using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;

    public static ProjectileMove Instance;

    public Vector3 targetPos = Vector3.zero;

    public Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        StartCoroutine(MoveProjectile());
    }

    public IEnumerator MoveProjectile()
    {
        if (transform.position == targetPos)
        {
            animator.SetBool("isExplode", true);
            yield return new WaitForSeconds(0.2f);

            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
