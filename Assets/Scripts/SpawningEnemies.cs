using System.Collections;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    public Transform firstPos, secondPos, thirdPos;
    public GameObject SpawnedMonster;
    public GameObject Player;
    public Rigidbody2D rb;
    private float nextSpawn = 0;
    private float SpawnRate = 5;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnRate;
            if (Player.transform.position.y > 9)
            {
                Instantiate(SpawnedMonster, thirdPos.position, Quaternion.identity);
            }
            else if (Player.transform.position.y < 3 && Player.transform.position.x > 20)
            {

                Instantiate(SpawnedMonster, firstPos.position, Quaternion.identity);
            }
            if (Player.transform.position.x < -1)
            {
                Instantiate(SpawnedMonster, secondPos.position, Quaternion.identity);
            }

        }
    }



}
