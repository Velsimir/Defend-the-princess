using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private State _currentState;

    private MainHero _mainHero;

    public State CurrentState => _currentState;

    private void Start()
    {
        _mainHero = GetComponent<Enemy>().GetTargetMainHero();

        Reset(_firstState );
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNext();

        if (nextState != null)
            Transsit(nextState);
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_mainHero);
    }

    private void Transsit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_mainHero );
    } 
}