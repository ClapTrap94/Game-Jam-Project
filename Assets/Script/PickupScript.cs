using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public enum PickedObject { Firewood }
    public PickedObject currentObject;
    public int pickupQuantity = 1;

    // Object Splash
    [SerializeField] Transform objTrans;
    private float _splashDelay = 0.6f;
    private float _currentTime = 0f;
    private Vector3 off;

    // Start is called before the first frame update
    void Start()
    {
        off = new Vector3(Random.Range(-2,2), Random.Range(-2, 2), off.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTime <= _splashDelay)
        {
            objTrans.position += off * Time.deltaTime;
            _currentTime += Time.deltaTime;
        }
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
