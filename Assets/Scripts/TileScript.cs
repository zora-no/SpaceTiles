using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{


    [SerializeField] private float effectDuration = 10f;
    [SerializeField] private int effectType = 3;
    [SerializeField] public bool effectIsActive = false;
    GameObject affectedPlayerObject;
    GameObject shootingPlayerObject;
    GameObject player1;
    GameObject player2;
    GameObject uiTilePowerup1;
    GameObject uiTilePowerup2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        uiTilePowerup1 = GameObject.Find("TilePowerup1");
        uiTilePowerup2 = GameObject.Find("TilePowerup2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // If wall hit by any ball
        if (other.tag == "Ball1" || other.tag == "Ball2")
        {
            // checks if no tile effect is active
            if (effectIsActive == false)
            {
                // check to affect the correct player
                if (other.tag == "Ball1")
                {
                    affectedPlayerObject = player2;
                    shootingPlayerObject = player1;
                    effectType = shootingPlayerObject.GetComponent<PlayerMovementScript>().tileEffectType;
                    uiTilePowerup1.GetComponent<uiTilePowerups>().SwitchImage(3);
                }
                else
                {
                    affectedPlayerObject = player1;
                    shootingPlayerObject = player2;
                    effectType = shootingPlayerObject.GetComponent<PlayerMovementScript>().tileEffectType;
                    uiTilePowerup2.GetComponent<uiTilePowerups>().SwitchImage(3);
                }
                
                // activate effect
                switch (effectType)
                {   
                    // Movement inhibitor powerup active
                    case 0:
                        FindObjectOfType<AudioManager>().Play("Tile");
                        gameObject.transform.Find("MovementInhibitor").gameObject.SetActive(true);
                        effectIsActive = true;
                        shootingPlayerObject.GetComponent<PlayerMovementScript>().ResetTileEffectType();
                        // StartCoroutine(DeactivateEffect(effectType));
                        break;
                    // Slow field powerup active
                    case 1:
                        FindObjectOfType<AudioManager>().Play("Tile");
                        gameObject.transform.Find("SlowField").gameObject.SetActive(true);
                        effectIsActive = true;
                        shootingPlayerObject.GetComponent<PlayerMovementScript>().ResetTileEffectType();
                        // StartCoroutine(DeactivateEffect(effectType));
                        break;
                    // Vision impairment powerup active
                    case 2:
                        FindObjectOfType<AudioManager>().Play("Tile");
                        gameObject.transform.Find("CloudedViewField").gameObject.SetActive(true);
                        effectIsActive = true;
                        shootingPlayerObject.GetComponent<PlayerMovementScript>().ResetTileEffectType();
                        // StartCoroutine(DeactivateEffect(effectType));
                        break;
                    // No tile powerup active
                    case 3:
                        break;
                }
            }
        }
    }

    
    public void DeactivateOnGameStart()
    {
        switch (effectType)
        {
            case 0:
                gameObject.transform.Find("MovementInhibitor").gameObject.SetActive(false);
                effectIsActive = false;
                break;
            case 1:
                gameObject.transform.Find("SlowField").gameObject.SetActive(false);
                effectIsActive = false;
                break;
            case 2:
                gameObject.transform.Find("CloudedViewField").gameObject.SetActive(false);
                effectIsActive = false;
                break;
        }
    }
    

    // Deactivates powerup effect
    IEnumerator DeactivateEffect(int type)
    {
        yield return new WaitForSeconds(effectDuration);
        switch (effectType)
        {
            case 0:
                gameObject.transform.Find("MovementInhibitor").gameObject.SetActive(false);
                effectIsActive = false;
                break;
            case 1:
                gameObject.transform.Find("SlowField").gameObject.SetActive(false);
                effectIsActive = false;
                affectedPlayerObject.GetComponent<PlayerMovementScript>().ResetMovespeed();
                break;
            case 2:
                gameObject.transform.Find("CloudedViewField").gameObject.SetActive(false);
                effectIsActive = false;
                // affectedPlayerObject.GetComponent<PlayerMovementScript>().ResetVision();
                break;
        }
    }
}
