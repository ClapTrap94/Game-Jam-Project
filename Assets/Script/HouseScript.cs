using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PickupScript;

public class HouseScript : MonoBehaviour
{
    // Player Script
    private PlayerScript player;

    // Firewood Variables
    public float pickupRate = 1.0f;
    public float burnRate = 1.0f;

    // Warmth Variables
    public float warmthRate = 1.0f;

    // Timers
    public float _timerTarget = 1.0f;
    private float _timerElapsed = 0.0f;
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
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}
