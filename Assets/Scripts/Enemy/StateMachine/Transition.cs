﻿using UnityEngine;
using System.Collections;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    protected Player Player { get; private set; }

    public State NextState => _nextState;
    public bool NeedTransit { get; protected  set; }

    public void Init(Player player)
    {
        Player = player;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}

