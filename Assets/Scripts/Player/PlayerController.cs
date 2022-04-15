using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float HorizontalInput;
    float VerticalInput;
    public float Speed = 20.0f;
    public float xRange = 18.0f;
    public float TopWalkRange = 18.0f;
    public float DownWalkRange = -10.0f;
    public GameObject Projectile;
    Vector3 originPosition;
    void Start()
    {
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        Vector3 targetPosition = transform.position + transform.right * HorizontalInput * Time.deltaTime * Speed;
        targetPosition += transform.forward * VerticalInput * Time.deltaTime * Speed;


        // 修正可移动范围
        if (targetPosition.x > xRange)
        {
            targetPosition.x = xRange;
        }
        else if (targetPosition.x < -xRange)
        {
            targetPosition.x = -xRange;
        }
        else if (targetPosition.z > TopWalkRange)
        {
            targetPosition.z = TopWalkRange;
        }
        else if (targetPosition.z < DownWalkRange)
        {
            targetPosition.z = DownWalkRange;
        }

        transform.position = targetPosition;
        if (Projectile != null && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Projectile, transform.position + transform.forward, Quaternion.identity);
        }
    }
}
