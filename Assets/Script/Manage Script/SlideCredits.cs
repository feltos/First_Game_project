using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlideCredits : MonoBehaviour
{
    [SerializeField]float CreditsMove;
    Text CreditsText;
	
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + CreditsMove);
    }
}

