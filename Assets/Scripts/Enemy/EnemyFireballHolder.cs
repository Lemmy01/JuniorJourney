using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireballHolder : MonoBehaviour
{
    [SerializeField] Transform enemy;
    void Update()
    {
        transform.localScale= enemy.localScale;
    }
}
