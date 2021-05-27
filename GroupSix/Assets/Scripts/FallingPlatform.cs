using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    PlayerHealth playerhealth;
    private void Start()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
    }
    public void KillPlayer()
    {
        playerhealth.UpdateHealth(-playerhealth.GetMaxHealth());
    }
}
