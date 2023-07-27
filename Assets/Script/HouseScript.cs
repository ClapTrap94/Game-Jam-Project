using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PickupScript;

public class HouseScript : MonoBehaviour
{
    // Player Script
    public GameObject player;
    private PlayerScript playerScript;

    // Firewood Variables
    public int pickupRate = 1;
    public float burnRate = 10.0f;
    public bool isBurning = true;
    public int firewoodInStorage = 10;

    // Warmth Variables
    public bool playerInArea = false;
    public int warmthRate = 2;

    // Timers
    private float _mainTimerElapsed = 0.0f;
    public float _timerPlayerTarget = 1.0f;
    private float _timerPlayerElapsed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBurning == true)
        {
            if (_mainTimerElapsed >= burnRate && firewoodInStorage > 0)
            {
                firewoodInStorage -= 1;

                _mainTimerElapsed = 0;
            }
            else if (firewoodInStorage <= 0)
            {
                isBurning = false;
                playerScript.isOutside = true;
                playerInArea = false;
            }
            _mainTimerElapsed += Time.deltaTime;
        }
        if (isBurning == true && playerInArea == true)
        {
            if (_timerPlayerElapsed >= _timerPlayerTarget)
            {
                // Firewood pickup
                if (playerScript.firewoodAmount > 0)
                {
                    playerScript.firewoodAmount -= pickupRate;
                    firewoodInStorage += pickupRate;
                }

                //Player warmth
                if (playerScript._currentHealth < playerScript.maxHealth)
                {
                    playerScript._currentHealth += warmthRate;
                    playerScript.healthBar.SetHealth(playerScript._currentHealth);
                }
                else if (playerScript._currentHealth >= playerScript.maxHealth)
                {
                    playerScript._currentHealth = playerScript.maxHealth;
                    playerScript.healthBar.SetHealth(playerScript._currentHealth);
                }
                _timerPlayerElapsed = 0;
            }
            _timerPlayerElapsed += Time.deltaTime;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isBurning == true)
        {
            playerScript.isOutside = false;
            playerInArea = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.isOutside = true;
            playerInArea = false;
        }
    }
}
