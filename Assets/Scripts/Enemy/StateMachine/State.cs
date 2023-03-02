using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Player { get; set; }

    public void Enter(Player player)
    {
        if (enabled == false)
        {
            Player = player;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(player); 
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
            if (transit.NeedTransit == true)
                return transit.NextState;
        }

        return null;
    }
}