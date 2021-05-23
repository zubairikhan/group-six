using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //[SerializeField] float shakeDuration= 0.5f;
    //[SerializeField] float magnitude= 0.2f;

    
    public IEnumerator ShakeCamera(float duration= 1f, float magnitude= 0.3f, bool fadeOut= false)
    {
        Vector3 orgPos = transform.localPosition;
        float initialMagnitude = magnitude;
        

        float count=0;

        while (count < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;
            transform.localPosition = new Vector3(x, y, orgPos.z);

            if (fadeOut && count > (duration * 0.75f))
            {
                magnitude -= initialMagnitude * 0.3f;
                magnitude = Mathf.Clamp(magnitude, 0, initialMagnitude);
            }
            count += Time.deltaTime;
            yield return null;
        }
    }
}
