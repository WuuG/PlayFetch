using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour, IHit
{
    // 这里通过Healt来实现hunger真的值得吗
    private Health HealthComp;
    public float CollisionDamage = 1.0f;
    public float MaxHunger = 3.0f;
    private void Awake()
    {
        HealthComp = new Health(MaxHunger);
    }
    public float hungerValue
    {
        get
        {
            // 将livs从3 -> 0 改未hungerValue从0 -> 3
            return -(HealthComp.Lives - MaxHunger);
        }
    }
    // Start is called before the first frame update

    public void OnHit(float Damage)
    {
        HealthComp.ChangeLives(Damage);
        if (hungerValue >= MaxHunger)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerStatus ps = other.GetComponent<PlayerStatus>();
        if (ps != null)
        {
            ps.OnHit(-CollisionDamage);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Coliision with animal");
    }
}
