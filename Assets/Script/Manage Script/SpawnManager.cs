using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]GameObject enemy;
    [SerializeField]float SpawnTime;
    public Transform[]SpawnPoints;
   
	
	void Start ()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
	}
	
	
	void Update ()
    {
	
	}

    void Spawn()
    {
        int SpawnPointIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(enemy, SpawnPoints[SpawnPointIndex].position, SpawnPoints[SpawnPointIndex].rotation);
    }
}
