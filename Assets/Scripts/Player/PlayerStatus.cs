using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IHit
{
    // 这里用 instance 那么双人游戏呢？ 
    public static PlayerStatus instance;
    Health HealthComp;
    float health { get => HealthComp.Lives; }
    public float MaxHealth = 3.0f;
    private void Awake()
    {
        HealthComp = new Health(MaxHealth);
        instance = this;
    }

    public void OnHit(float Damage)
    {
        HealthComp.ChangeLives(Damage);

        Debug.Log($"Player Health : {health}");
        Debug.Log($"Player Health : {HealthComp.Lives}");
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }

}
