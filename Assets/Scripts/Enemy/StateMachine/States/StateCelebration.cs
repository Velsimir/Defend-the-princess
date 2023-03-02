using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateCelebration : State
{
    private const string EnemyCelebration = "Enemy_Celebration";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(EnemyCelebration);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
