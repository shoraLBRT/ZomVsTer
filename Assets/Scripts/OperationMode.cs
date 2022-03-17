using Internal;
using System;
using System.Collections.Generic;
using UnityEngine;

public class OperationMode : MonoBehaviour
{
    private Dictionary<Type, IOperatingState> _statesGroup;
    private IOperatingState _currentState;

    [SerializeField]
    private OperatingOfZombie _operatingOfZombie;

    private void Awake()
    {
        Locator.Register<OperationMode>(this);
    }
    private void Start()
    {
        InitStates();
        SetStateByDefault();
    }
    private void InitStates()
    {
        _statesGroup = new Dictionary<Type, IOperatingState>();
        _statesGroup[typeof(OperatingOfZombie)] = _operatingOfZombie;
        _statesGroup[typeof(OperatingOfBodyParts)] = new OperatingOfBodyParts();
        _statesGroup[typeof(OperationDisabled)] = new OperationDisabled();
    }
    private void SetState(IOperatingState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = newState;
        _currentState.Enter();
    }
    public void SetStateByDefault()
    {
        SetStateOperationOfZombie();
    }
    private IOperatingState GetState<T>() where T : IOperatingState
    {
        var type = typeof(T);
        return _statesGroup[type];
    }
    private void Update()
    {
        if (_currentState != null)
            _currentState.Update();
    }
    public void SetStateOperationOfZombie()
    {
        IOperatingState state = GetState<OperatingOfZombie>();
        SetState(state);
    }
    public void SetStateOperationOfBodyParts()
    {
        IOperatingState state = GetState<OperatingOfBodyParts>();
        SetState(state);
    }
    public void SetStateOperationDisabled()
    {
        IOperatingState state = GetState<OperationDisabled>();
        SetState(state);
    }
}
