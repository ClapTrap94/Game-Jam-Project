using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public enum PickedObject { Firewood }
    public PickedObject currentObject;
    public int pickupQuantity = 1;
    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentObject == PickedObject.Firewood)
            {
                collision.GetComponent<PlayerScript>().firewoodAmount += pickupQuantity;
                Debug.Log(collision.GetComponent<PlayerScript>().firewoodAmount);
            }
            /*else if (currentObject == PickedObject.Firewood)
            {
                
            }*/
            Destroy(gameObject);
        }
    }
}
