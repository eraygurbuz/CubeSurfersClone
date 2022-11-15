using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    [SerializeField] private CubeHandler cubeHandler;

    [SerializeField] private GameManager gameManager;

    public ParticleSystem gemParticle;

    private void Start()
    {
        cubeHandler = GameObject.FindObjectOfType<CubeHandler>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CollectableCube")
        {
            other.tag = "Cube";
            cubeHandler.AddBlock(other.gameObject);
        }

        else if(other.tag == "Gem")
        {
            Destroy(other.gameObject);
            Instantiate(gemParticle, other.gameObject.transform.position, Quaternion.identity);
            gameManager.TakeGem();
        }

        else if(other.tag == "Finish")
        {
            gameManager.LevelFinished();
        }

        else if(other.tag == "LastPlatform")
        {
            Debug.Log("LAST PLATFORM UPDATE");
            cubeHandler.UpdateGroundLevel(3.5f);
        }
    }
}
