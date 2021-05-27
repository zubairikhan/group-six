using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWeakGround : MonoBehaviour
{
    [SerializeField] TrapObstacle trapObstacle;
    [SerializeField] BreakablePlatform breakablePlatform;
    bool done= false;

    private void Start()
    {
        trapObstacle = FindObjectOfType<TrapObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!done && breakablePlatform.isBroken())
        {
            trapObstacle.PlayAnimation();
            done = true;
        }
    }
}
