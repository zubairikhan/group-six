using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlaceTrigger : MonoBehaviour
{
    [SerializeField] TrapObstacle trapObstacle;
    [SerializeField] Block block;
    // Start is called before the first frame update
    void Start()
    {
        trapObstacle = FindObjectOfType<TrapObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MoveableBlock")
        {
            trapObstacle.SetBoolBlockPlaced(block, true);
        }
    }

    
}
public enum Block
{
    right,
    left
}
