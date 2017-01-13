using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]GameObject enemy;
    [SerializeField]float EnemmySpawnTime;
    [SerializeField]Transform[]SpawnPoints;
    
    
    
  
   
	void Start ()
    {
        InvokeRepeating("EnemmySpawn", EnemmySpawnTime, EnemmySpawnTime);
        
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

 

}
