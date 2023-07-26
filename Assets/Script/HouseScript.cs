using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PickupScript;

public class HouseScript : MonoBehaviour
{
    // Player Script
    private PlayerScript player;

    // Firewood Variables
    public int pickupRate = 1;
    public float burnRate = 1.0f;
    public bool isBurning = true;
    private int firewoodInStorage = 10;

    // Warmth Variables
    public float warmthRate = 1.0f;

    // Timers
    private float _mainTimerElapsed = 0.0f;
    public float _timerPlayerTarget = 1.0f;
    private float _timerPlayerElapsed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_mainTimerElapsed <= burnRate && isBurning == true) 
        {
            firewoodInStorage -= 1;

            _mainTimerElapsed += Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isBurning == true)
        {
            if (_timerPlayerElapsed < _timerPlayerTarget)
            {
                // Firewood pickup
                if (player.firewoodAmount > 0)
                {
                    player.firewoodAmount -= pickupRate;
                    firewoodInStorage += pickupRate;
                }

                // Player warmth
                /*if (player._currentHealth < player.maxHealth)
                {
                    player._currentHealth += warmthRate;
                }
                else if (player._currentHealth >= player.maxHealth)
                {
                    player._currentHealth = player.maxHealth;
                }*/

                _timerPlayerElapsed += Time.deltaTime;
            }

        }
    }
}
