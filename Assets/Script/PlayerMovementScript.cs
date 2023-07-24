using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D _rb;
    Collider2D _collider;

    Animator animator;
    SpriteRenderer _sprite;
    [SerializeField] Transform _attackpoint;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] LayerMask destructiblesLayers;
    float attackRadius = 0.5f;
    float movementSpeed = 3.0f;

    private Vector2 movement;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < -0.01)
        {
            _sprite.flipX = true;
        }
        if (movement.x > 0.01)
        {
            _sprite.flipX = false;
        }
        if (movement.x == 0)
        {
            _sprite.flipX = false;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        //movement
        _rb.MovePosition(_rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    private void Attack()
    {
        //Animation
        animator.SetTrigger("Attack");

        //Check Colliders
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(_attackpoint.position, attackRadius, enemyLayers);
        Collider2D[] destructiblesHit = Physics2D.OverlapCircleAll(_attackpoint.position, attackRadius, destructiblesLayers);

        Debug.Log("We hit " + enemiesHit.Length + " enemies");
        Debug.Log("We hit " + destructiblesHit.Length + " destructibles");
        //Deal damage to enemies
        foreach (Collider2D enemy in enemiesHit)
        {
            Debug.Log("We hit "+ enemy);
        }

        //Deal damage to destructibles

        foreach (Collider2D destructible in destructiblesHit)
        {
            Debug.Log("We hit " + destructible);
        }

    }
}
