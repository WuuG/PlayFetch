using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollsion : MonoBehaviour
{
    public float ProjectileDamage = 1.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStatus>() != null)
        {
            return;
        }

        IHit beHit = other.GetComponent<IHit>();
        if (beHit != null)
        {
            beHit.OnHit(-ProjectileDamage);
            Destroy(gameObject);
        }
    }
}
