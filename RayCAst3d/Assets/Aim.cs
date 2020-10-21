using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MyEnum
{
    Horizontal,
    Vertical
}
public class Aim : MonoBehaviour
{
    private Vector3 Velocity;
    [SerializeField]private MyEnum tap;
    private void Start()
    {
        if (tap == MyEnum.Horizontal)
        {
          Velocity = Vector3.right;  
        }

        if (tap == MyEnum.Vertical)
        {
            Velocity = Vector3.back;
        }
        
    }

    private void Update()
    {
        transform.Translate(Velocity*1.5f*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Velocity *= -1;
    }
}
