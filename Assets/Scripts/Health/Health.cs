using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    // Start is called before the first frame update
    public Health()
    {
        this.MaxLives = 3.0f;
        this.Lives = this.MaxLives;
        Debug.LogWarning($"Health Component dont't has MaxLives, Please Use Healt(float MaxLives) to Construct Health Comp");
    }
    public Health(float MaxLives)
    {
        this.MaxLives = MaxLives;
        this.Lives = MaxLives;
    }
    private float _lives;

    public float MaxLives { get; set; }
    public float Lives
    {
        get => this._lives;
        set
        {
            this._lives = Mathf.Clamp(value, 0, MaxLives);
        }
    }
    public bool ChangeLives(float deltaLive)
    {
        if (Lives <= 0)
        {
            return false;
        }

        Lives = Mathf.Clamp(Lives + deltaLive, 0, MaxLives);
        return true;
    }
}
