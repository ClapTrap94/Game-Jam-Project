using UnityEngine;
using static PickupScript;

public class DestructibleScript : MonoBehaviour
{
    // Import
    [SerializeField] GameObject firewoodObject;

    // Object type
    public enum DestructibleType {TREE,BRANCH,BUSH}
    public DestructibleType currentObject;
    private int firewoodDroprate;

    // Health Variables
    [SerializeField] private int maxHealth = 120;
    private int _currentHealth;
    private bool _isAlive = true;

    private void Start()
    {
        _currentHealth = maxHealth;
    }
    private void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _isAlive = false;
            Die();
        }
    }
    private void Die()
    {
        switch (currentObject)
        {
            case DestructibleType.TREE:
                firewoodDroprate = 3;
                //Instantiate();
                break;
            case DestructibleType.BRANCH:
                firewoodDroprate = 1;
                break;
            case DestructibleType.BUSH:
                firewoodDroprate = 1;
                break;
        }

        Destroy(gameObject);
    }
}
