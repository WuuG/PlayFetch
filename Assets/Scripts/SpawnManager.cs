using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    enum SpawnPosition : byte
    {
        SpawnAtTop,
        SpawnAtSide
    }
    public GameObject[] AnimalPrefabs;
    [Header("Top Spwan Position Params")]
    public float SpawnPosZ = 20.0f;
    public float SpawnRangeTop = 20.0f;

    [Header("Left And Right Spwan Position Params")]
    public float SpawnPosX = 20.0f;
    public float SpawnSideTopZ = 20.0f;
    public float SpawnSideDownZ = -5.0f;
    [Space(10)]
    public float starDely = 2.0f;
    public float spawnInterval = 1.5f;
    void Start()
    {
        InvokeRepeating("SpawnAnimal", starDely, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnAnimal()
    {
        SpawnPosition anchorPosition = Tools.RandomEnumValue<SpawnPosition>();
        Vector3? spawnPosition = null;
        Quaternion? lookDirection = null;

        // 在侧边生成动物
        if (anchorPosition == SpawnPosition.SpawnAtSide)
        {
            // 判断是左边还是右边生成, 并获取生成位置
            float Negetive = Random.value < 0.5f ? -1f : 1f;
            float SpawnPositionX = Negetive * SpawnPosX;
            lookDirection = Quaternion.LookRotation(-Negetive * Vector3.right);

            spawnPosition = new Vector3(SpawnPositionX, 0, Random.Range(SpawnSideDownZ, SpawnSideTopZ));
        }
        // 在顶部生成动物
        else if (anchorPosition == SpawnPosition.SpawnAtTop)
        {
            lookDirection = Quaternion.LookRotation(Vector3.back);
            spawnPosition = new Vector3(Random.Range(-SpawnRangeTop, SpawnRangeTop), 0, SpawnPosZ);
        }

        int animalIndex = Random.Range(0, AnimalPrefabs.Length);
        if (spawnPosition != null && lookDirection != null)
        {
            Instantiate(AnimalPrefabs[animalIndex], (Vector3)spawnPosition, (Quaternion)lookDirection);
        }
    }
}
