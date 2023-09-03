using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusUpState : PlayerState
{
    public PlayerBonusUpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName) // 생성자 
    {

    }
    // code by 동호
    public override void Enter()
    {
        base.Enter(); // 부모의 Enter 함수 실행 
        player.rb.gravityScale = 0; // 중력을 0으로 반듬   

    }
    // code by 동호
    public override void Exit()
    {
        base.Exit(); // 부모의 Exit 함수 실행 

    }
    // code by 동호
    public override void Update()
    {
        base.Update(); // 부모의 Update 함수 실행 
        //if (!player.isBonusTime)
        //{
        //    stateMachine.ChangeState(player.fallingState);  
        //}
        if(player.gValue <= 0 && player.isBonusTime == false && player.isBonusStart)
        {
            stateMachine.ChangeState(player.fallingState);

        }
    }
}
