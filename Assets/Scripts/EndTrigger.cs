using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public int multiplier = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Debug.Log(other.gameObject.name);
            if(other.gameObject.GetComponent<CubeBehaviour>().getIsLastCube())
                FindObjectOfType<GameManager>().CompleteLevel(multiplier);
        }
        
    }
}
