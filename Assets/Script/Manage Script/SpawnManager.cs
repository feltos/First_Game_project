using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]GameObject enemy;
    [SerializeField]GameObject Item;
    [SerializeField]float EnemmySpawnTime;
    [SerializeField]float ItemSpawnTime;
    [SerializeField]Transform[]SpawnPoints;
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

    double [] probabilities = new double[(int)Effects.Length]
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
        if (ScoreManager.Score < 300)
        {
            int SpawnPointIndex = Random.Range(0, SpawnPoints.Length);
            Instantiate(enemy, SpawnPoints[SpawnPointIndex].position, SpawnPoints[SpawnPointIndex].rotation);
        }
    }

    void ItemSpawn()
    {
        if (ScoreManager.Score < 300)
        {
            int SpawnItemIndex = Random.Range(0, ItemSpawnPoints.Length);
            Instantiate(Item, ItemSpawnPoints[SpawnItemIndex].position, ItemSpawnPoints[SpawnItemIndex].rotation);
        }
    }

}
