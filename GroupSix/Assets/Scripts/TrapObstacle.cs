using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObstacle : MonoBehaviour
{
    [SerializeField] bool leftBlockPlaced;
    [SerializeField] bool rightBlockPlaced;
    [SerializeField] Animator anim;
    

    public void SetBoolBlockPlaced(Block block, bool status)
    {
        if (block == Block.left)
        {
            leftBlockPlaced = status;
        }
        else
        {
            rightBlockPlaced = status;
        }
        
    }

    public void PlayAnimation()
    {
        if (leftBlockPlaced && rightBlockPlaced)
        {
            anim.SetBool("success", true);
        }
        else if(!leftBlockPlaced && !rightBlockPlaced)
        {
            anim.SetBool("failure0", true);
        }
    }

    
    
}
