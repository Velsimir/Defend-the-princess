using UnityEngine;
using System.Collections;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    protected MainHero MainHero { get; private set; }

    public State NextState => _nextState;
    public bool NeedTransit { get; set; }

    public void Init(MainHero mainHero)
    {
        MainHero = mainHero;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}

