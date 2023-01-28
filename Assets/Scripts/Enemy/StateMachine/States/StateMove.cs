using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, MainHero.transform.position, _speed * Time.deltaTime);
    }
}
