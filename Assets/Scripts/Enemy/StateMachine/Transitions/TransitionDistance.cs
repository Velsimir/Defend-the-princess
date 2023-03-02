using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDistance : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpeard;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpeard, _rangeSpeard);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < _transitionRange)
            NeedTransit = true;
    }
}
