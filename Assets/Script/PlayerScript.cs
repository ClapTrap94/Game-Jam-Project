using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Import Componenets
    Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    SpriteRenderer _sprite;

    // Movement Variables
    public float movementSpeed = 5.0f;
    private Vector2 _movement;

    // Health Variables
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int _currentHealth;
    private bool _isAlive = true;
    public int damageOverTime = 1;

    // Scoring Variables
    public Scoring scoreTracker;
    public int score = 0;



    // Attack Variables
    private bool _isAttacking = false;
    [SerializeField] Transform _attackPoint;
    [SerializeField] SpriteRenderer _attackPointSprite;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] LayerMask destructiblesLayers;
    [SerializeField] float _attackRadius = 0.5f;
    [SerializeField] float _attackRate = 2f;
    [SerializeField] int _attackDamage = 34;
    float _nextAttackTime = 0f;

    // Player Inventory
    public int firewoodAmount;

    // Player timer
    public float logTimer = 0f;
    private float logInterval = 3f;
    public bool isOutside = true;


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        firewoodAmount = 0;
    }

    public void Start()
    {
        _currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        if (Time.time >= _nextAttackTime)
        {

            //Attack();
        }

    
    }
  
    private void FixedUpdate()
    {
        if (_isAlive == true) 
        {
            //movement
            _rb.MovePosition(_rb.position + _movement * movementSpeed * Time.fixedDeltaTime);

            // Attack point movement
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                _attackPoint.transform.localPosition = new Vector2(_movement.x, _movement.y);
            }

            // Take damage
            if (isOutside)
            {
                if (logTimer >= logInterval)
                {
                    IncreaseScore();
                    TakeDamage(damageOverTime);

                    logTimer = 0f;

                }
                else
                {
                    logTimer += Time.fixedDeltaTime;
                }
            }
        }
        

        
    }

    public void IsOutside(bool Outside)
    {
        isOutside = Outside;
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
            Debug.Log("We hit " + enemy);
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

    public void IncreaseScore()
    {
        score+=10;
        scoreTracker.IncreaseScore(score);
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        _isAlive = false;
        _animator.SetTrigger("Die");
    }

}
