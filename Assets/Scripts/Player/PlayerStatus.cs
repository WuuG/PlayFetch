using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, IHit
{
    // 这里用 instance 那么双人游戏呢？ 
    public static PlayerStatus instance;
    Health HealthComp;
    float health { get => HealthComp.Lives; }
    public float MaxHealth = 3.0f;
    public float Score { get; private set; }
    public Slider HealthBar;
    private void Awake()
    {
        HealthComp = new Health(MaxHealth);
        instance = this;
    }
    private void Start()
    {
        if (HealthBar != null)
        {
            HealthBar.maxValue = MaxHealth;
            HealthBar.value = health;
        }
    }

    public void OnHit(float Damage)
    {
        HealthComp.ChangeLives(Damage);
        ChangeHealthBar(health);

        Debug.Log($"player SCore : {Score}");
        Debug.Log($"Player Health : {health}");
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    public void AddScore(float DeltaScore)
    {
        Score += DeltaScore;
    }
    void ChangeHealthBar(float health)
    {
        if (HealthBar != null)
        {
            HealthBar.fillRect.gameObject.SetActive(true);
            HealthBar.value = health;
        }
    }
}
