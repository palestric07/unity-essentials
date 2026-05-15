using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class player : MonoBehaviour

{
    [SerializeField]
    private string _horizontalaxis ="Horizontal", _verticalaxis="Vertical";
    [SerializeField]
    private Rigidbody2D _rb2d;
    
    private Vector2 _input;

    private void FixedUpdate()
    {
        _rb2d.linearVelocity = (_input);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalinput= Input.GetAxisRaw(_horizontalaxis);
        float vertcalinput= Input.GetAxisRaw(_verticalaxis);
        _input = new Vector2(horizontalinput, vertcalinput);
    }
}

