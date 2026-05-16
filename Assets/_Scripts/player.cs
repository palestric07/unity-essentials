using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour

{
    [SerializeField]
    private string _horizontalaxis ="Horizontal", _verticalaxis="Vertical";
    [SerializeField]
    private Rigidbody2D _rb2d;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    public UnityEvent onPlayerDeath = null;

    private Vector2 _input;

    private void FixedUpdate()
    {
        _rb2d.linearVelocity = (_input * _speed);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalinput= Input.GetAxisRaw(_horizontalaxis);
        float vertcalinput= Input.GetAxisRaw(_verticalaxis);
        _input = new Vector2(horizontalinput, vertcalinput);
        _input.Normalize();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    { 
            if ( onPlayerDeath != null)
            {
                 onPlayerDeath.Invoke();
            }
        Destroy(gameObject);
    }
}
}