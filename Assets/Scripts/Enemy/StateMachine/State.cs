using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class State : MonoBehaviour
{
    private List<Transition> _transitions;

    protected MainHero MainHero { get; set; }

    public void Enter(MainHero mainHero)
    {
        if (enabled == false)
        {
            MainHero = mainHero;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(mainHero); 
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
        }

        enabled = false;
    }

    public State GetNext()
    {
        foreach (var transit in _transitions)
        {
            if (transit.NeedTransit)
                return transit.NextState;
        }

        return null;
    }
}