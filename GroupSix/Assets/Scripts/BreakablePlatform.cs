using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] List<Rigidbody2D> childrenRbs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stomper")
        {
            Break();
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

    protected void Break()
    {
        ChangeRigidbodies();
        
    }

    private void ChangeRigidbodies()
    {
        
        foreach (var rock in childrenRbs)
        {
            rock.isKinematic = false;
            
        }
    }
}
