using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTargetDie : Transition
{
    private void Update()
    {
        if (MainHero == null)
            NeedTransit = true;
    }
}
