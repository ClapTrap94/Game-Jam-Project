using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Health Variables
    [SerializeField] private int maxHealth = 100;
    private int _currentHealth;
    private bool _isAlive = true;

    //Attack Variables

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
        Destroy(gameObject);
    }

}
