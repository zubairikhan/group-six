using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float lerpingRatio = 0.1f;
    [SerializeField] Vector3 shakeOffset;
    [SerializeField] float minPosY;

    private void Update()
    {
        /*Vector3 pos = transform.position;
        shakeOffset = -shakeOffset;
        pos += shakeOffset;
        transform.position = pos;
        */
    }


    void FixedUpdate()
    {
        Vector3 newPos = player.position + offset;
        Vector3 pos= Vector3.Lerp(transform.position, newPos, lerpingRatio);
        pos.y = Mathf.Clamp(pos.y, minPosY, pos.y);
        transform.localPosition = pos;
    }
}
