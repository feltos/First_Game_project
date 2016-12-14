using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;     
    private Vector3 offset;        

    
    void Start()
    {
        
        offset = transform.position - player.transform.position;
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
    }

    
    void LateUpdate()
    {
        
        transform.position = player.transform.position + offset;
    }

}
