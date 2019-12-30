using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float rotationTime = .5f;
    [SerializeField] private Transform back;
    [SerializeField] private Transform circles;

    private readonly WaitForFixedUpdate fu = new WaitForFixedUpdate(); 
    
    private bool isRotating;

    private float times;
    private float angle; 

    private void Start()
    {
        times = rotationTime / Time.fixedDeltaTime;
        angle = 30 / times; 
    }

    void Update()
    {
        if (isRotating) return;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Rotation(1));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Rotation(-1));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            circles.Rotate(0, 0, angle);
        }
        if (Input.GetKey(KeyCode.E))
        {
            circles.Rotate(0, 0, -angle);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            circles.rotation = Quaternion.identity;
        }
    }

    IEnumerator Rotation(float multiplier)
    {
        isRotating = true;
        for (int i = 0; i < times; i++)
        {
            back.Rotate(0, 0, angle * multiplier);
            yield return fu;
        }
        isRotating = false;
    }
}
