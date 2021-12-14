using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [HideInInspector]
    public bool ballDestroyed = false;
    private GameController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        else if (gameControllerObject == null)
        {
            Debug.Log("Cannot find game controller script on GameController Object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ballDestroyed = true;
        Destroy(other.gameObject);
        gameControllerScript.BallCreator();
    }
}
