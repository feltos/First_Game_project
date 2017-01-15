using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;     
    private Vector3 offset;
    float minPosX = -12f;
    float maxPosX = 13f;
    float minPosY = -5f;
    float maxPosY = 5f;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        Vector3 CameraPosition = player.transform.position + offset;
        if(CameraPosition.x < minPosX)
        {
            CameraPosition.x = minPosX;
        }
        if(CameraPosition.x > maxPosX)
        {
            CameraPosition.x = maxPosX;
        }
        if (CameraPosition.y < minPosY)
        {
            CameraPosition.y = minPosY;
        }
        if (CameraPosition.y > maxPosY)
        {
            CameraPosition.y = maxPosY;
        }
        transform.position = CameraPosition;

    }

}
