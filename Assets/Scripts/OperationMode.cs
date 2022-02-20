using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationMode : MonoBehaviour
{
    private Dictionary<Type, OperatingState> _statesGroup;
    private OperatingState _currentState;

    private void Start()
    {
        InitStates();
        SetStateByDefault();
    }
    private void InitStates()
    {
        _statesGroup = new Dictionary<Type, OperatingState>();
        _statesGroup[typeof(OperatingOfPlayer)] = new OperatingOfPlayer();
        _statesGroup[typeof(OperatingOfBodyParts)] = new OperatingOfBodyParts();
        _statesGroup[typeof(OperationDisabled)] = new OperationDisabled();
    }
    private void SetState(OperatingState newState)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
    private void SetStateByDefault()
    {
        SetStateOperationOfPlayer();
    }
    private OperatingState GetState<T>() where T : OperatingState
    {
        var type = typeof(T);
        return _statesGroup[type];
    }
    //private void Update()
    //{
    //    if (_currentState != null)
    //        _currentState.Update();
    //}
    public void SetStateOperationOfPlayer()
    {
        OperatingState state = GetState<OperatingOfPlayer>();
        SetState(state);
    }
    public void SetStateOperationOfBodyParts()
    {
        OperatingState state = GetState<OperatingOfBodyParts>();
        SetState(state);
    }
    public void SetStateOperationDisabled()
    {
        OperatingState state = GetState<OperationDisabled>();
        SetState(state);
    }
}
