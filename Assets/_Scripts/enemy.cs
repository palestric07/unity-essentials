using UnityEngine;
using System;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private float _Speed = 1f;
    private Rigidbody2D _rb2d;
    private Transform _playertransform;
    public bool stopped = false;
    [SerializeField]
    private GameObject _crabDead; 
   
    public event Action onEnemyDeath = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        
        // Player script ko dhoondne ke liye
        player playerObj = FindAnyObjectByType<player>();
        
        if(playerObj != null)
        {
            _playertransform = playerObj.transform;
        } 
        else
        {
            stopped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(stopped || _playertransform == null)
        {
            _rb2d.linearVelocity = Vector2.zero;
            return;
        }
        Vector3 directionToPlayer = _playertransform.position - transform.position;
        _rb2d.linearVelocity = directionToPlayer.normalized * _Speed;
    }

    // 1. Agar Collider normal hai (Is Trigger OFF hai)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            HandleDeath();
        }
    }

    // 2. Agar Collider trigger hai (Is Trigger ON hai)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            HandleDeath();
            if (onEnemyDeath != null)
            {
                onEnemyDeath();
            }
        }
    }

    // Enemy ko khatam karne aur dead prefab banane ka function
    private void HandleDeath()
    {
        if (_crabDead != null)
        {
            Instantiate(_crabDead, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}