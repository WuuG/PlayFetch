using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutBound : MonoBehaviour
{
    public float TopBound = 30f;
    public float DownBound = -7f;
    public float SideBound = 30f;

    public float OutOfAreaDamage = 1.0f;
    private PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        // playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        playerStatus = PlayerStatus.instance;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        float transFormZ = transform.position.z;
        if (transFormZ > TopBound)
        {
            Destroy(gameObject);
        }
        else if (Mathf.Abs(transform.position.x) > SideBound)
        {
            playerStatus.OnHit(-OutOfAreaDamage);
            Destroy(gameObject);
        }
        else if (transFormZ < DownBound)
        {
            playerStatus.OnHit(-OutOfAreaDamage);
            Destroy(gameObject);
        }
    }
}
