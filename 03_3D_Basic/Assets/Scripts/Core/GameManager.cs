using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// 플레이어
    /// </summary>
    Player player;

    /// <summary>
    /// 플레이어 확인용 프로퍼티
    /// </summary>
    public Player Player => player;

<<<<<<< HEAD
    ///// <summary>
    ///// 가상 스틱
    ///// </summary>
    //VirtualStick stick;

    ///// <summary>
    ///// 가상 스틱 확인용 프로퍼티
    ///// </summary>
    //public VirtualStick Stick => stick;

    ///// <summary>
    ///// 가상버튼(점프)
    ///// </summary>
    //VirtualButton jumpButton;

    ///// <summary>
    ///// 가상버튼(점프) 확인용 프로퍼티
    ///// </summary>
    //public VirtualButton JumpButton => jumpButton;

    /// <summary>
    /// 가상 패드
    /// </summary>
    VirtualPad virtualPad;

    /// <summary>
    /// 가상패드 참조용 프로퍼티
    /// </summary>
=======
    /// <summary>
    /// 가상 패드
    /// </summary>
    VirtualPad virtualPad;

    /// <summary>
    /// 가상패드 참조용 프로퍼티
    /// </summary>
>>>>>>> bc338778f32f4a12608f8d016edac856fe636b13
    public VirtualPad VirtualPad => virtualPad;


    /// <summary>
    /// 초기화용 함수
    /// </summary>
    protected override void OnInitialize()
    {
<<<<<<< HEAD
        player = FindAnyObjectByType<Player>();        
        //stick = FindAnyObjectByType<VirtualStick>();
        //jumpButton = FindAnyObjectByType<VirtualButton>();

=======
        player = FindAnyObjectByType<Player>();
>>>>>>> bc338778f32f4a12608f8d016edac856fe636b13
        virtualPad = FindAnyObjectByType<VirtualPad>();
    }
}
