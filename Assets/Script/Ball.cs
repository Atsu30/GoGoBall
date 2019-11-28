using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate();

    }
}
