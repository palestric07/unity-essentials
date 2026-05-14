 using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
public class weapon: MonoBehaviour
{
    [SerializeField]
    private int Rotationspeed=200;
    [SerializeField]
    private Vector3 rotationpoint= Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float rotationamount=  Rotationspeed *Time.deltaTime;
            transform.RotateAround(rotationpoint, Vector3.forward,rotationamount);
    }
}
