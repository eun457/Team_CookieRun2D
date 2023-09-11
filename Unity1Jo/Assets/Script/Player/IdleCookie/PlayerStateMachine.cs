using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }
    //���� ���¸� �����Ѵ�

    public void Initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit(); //���� State ������
        currentState = _newState;
        currentState.Enter(); //���ο� State ����
    }
}
