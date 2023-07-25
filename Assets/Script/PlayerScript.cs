using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Import Componenets
    Rigidbody2D _rb;
    Collider2D _collider;
    Animator _animator;
    SpriteRenderer _sprite;

    // Movement Variables
    public float movementSpeed = 5.0f;
    private Vector2 _movement;

    // Health Variables
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float maxTemp = 100f;
    private int _currentHealth;
    private float _currentTemp;
    private bool _isAlive = true;

    // Attack Variables
    private bool _isAttacking = false;
    [SerializeField] Transform _attackPoint;
    [SerializeField] SpriteRenderer _attackPointSprite;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] LayerMask destructiblesLayers;
    [SerializeField] float _attackRadius = 0.5f;
    [SerializeField] int _attackDamage = 34;

    // Player Inventory
    public int firewoodAmount;


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        firewoodAmount = 0;
}

    private void Start()
    {
        _currentHealth = maxHealth;
        _currentTemp = maxTemp;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement directions:
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (_movement.x < -0.01)
        {
            _sprite.flipX = true;
        }
        if (_movement.x > 0.01)
        {
            _sprite.flipX = false;
        }
        if (_movement.x == 0)
        {
            _sprite.flipX = false;
        }
        _animator.SetFloat("Horizontal", _movement.x);
        _animator.SetFloat("Vertical", _movement.y);
        _animator.SetFloat("Speed", _movement.sqrMagnitude);

        // Attack
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Attack();
        }
    }
    private void FixedUpdate()
    {
        //movement
        _rb.MovePosition(_rb.position + _movement * movementSpeed * Time.fixedDeltaTime);
    }
    private void Attack()
    {

        _isAttacking = true;
        _attackPointSprite.enabled = true;

        //Animation
        _animator.SetTrigger("Attack");



        //Check Colliders
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, enemyLayers);
        Collider2D[] destructiblesHit = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, destructiblesLayers);

        //Deal damage to enemies
        foreach (Collider2D enemy in enemiesHit)
        {
            Debug.Log("We hit "+ enemy);
            enemy.GetComponent<EnemyScript>().TakeDamage(_attackDamage);
        }

        //Deal damage to destructibles

        foreach (Collider2D destructible in destructiblesHit)
        {
            Debug.Log("We hit " + destructible);
            destructible.GetComponent<DestructibleScript>().TakeDamage(_attackDamage);
        }

        _attackPointSprite.enabled = false;
        _isAttacking = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
}
