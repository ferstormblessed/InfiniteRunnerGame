using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetYPos : MonoBehaviour
{
    [SerializeField] private float _targetYPos = 0;

    private void Start()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.y = _targetYPos;
        transform.position = currentPosition;
    }
}
