using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]GameObject enemy;
    [SerializeField]GameObject Item;
    [SerializeField]float EnemmySpawnTime;
    [SerializeField]float ItemSpawnTime;
    [SerializeField] Transform[]SpawnPoints;
    [SerializeField]Transform[] ItemSpawnPoints;

    
    enum Effects
    {
        HealthBonus,
        DamageBonus,
        InfiniteJump,
        Shield,
        HealthMalus,
        NoJump,
        NoShoot,
        Length
    };

    double [] probabilities = 
    {
        5,
        5,
        2,
        3,
        1,
        1,
        1
    };
   
	void Start ()
    {
        InvokeRepeating("EnemmySpawn", EnemmySpawnTime, EnemmySpawnTime);
        InvokeRepeating("ItemSpawn", ItemSpawnTime, ItemSpawnTime);
	}
	
	
	void Update ()
    {
	
	}

    void EnemmySpawn()
    {
        int SpawnPointIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(enemy, SpawnPoints[SpawnPointIndex].position, SpawnPoints[SpawnPointIndex].rotation);
    }

    void ItemSpawn()
    {
        int SpawnItemIndex = Random.Range(0, ItemSpawnPoints.Length);
        Instantiate(Item, ItemSpawnPoints[SpawnItemIndex].position, ItemSpawnPoints[SpawnItemIndex].rotation);
    }
}
