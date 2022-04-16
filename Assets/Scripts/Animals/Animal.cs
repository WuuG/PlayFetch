using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour, IHit
{
    // 这里通过Healt来实现hunger真的值得吗
    private Health HealthComp;
    public float CollisionDamage = 1.0f;
    public float MaxHunger = 3.0f;
    public float score = 3.0f;
    public Slider hungerSlider;
    float hungerValue
    {
        // 将livs从3 -> 0 改未hungerValue从0 -> 3
        get => -(HealthComp.Lives - MaxHunger);
    }

    private void Awake()
    {
        HealthComp = new Health(MaxHunger);
    }
    private void Start()
    {
        if (hungerSlider == null)
        {
            throw new UnassignedReferenceException("animal did not attach slider ui");
        }
        hungerSlider.maxValue = MaxHunger;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
    }

    // Start is called before the first frame update

    public void OnHit(float Damage)
    {
        HealthComp.ChangeLives(Damage);
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = hungerValue;

        if (hungerValue >= MaxHunger)
        {
            PlayerStatus.instance.AddScore(score);
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
