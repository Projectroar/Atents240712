using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyBase : RecycleObject
{
    /// <summary>
    /// 적의 수명
    /// </summary>
    public float lifeTime = 30.0f;

    /// <summary>
    /// 이동 속도
    /// </summary>
    public float moveSpeed = 3.0f;

    /// <summary>
    /// 이 적을 죽였을 때 얻는 점수
    /// </summary>
    public int point = 10;

    /// <summary>
    /// 적의 최대 HP
    /// </summary>
    public int maxHP = 1;

    /// <summary>
    /// 적의 HP
    /// </summary>
    int hp = 1;

    /// <summary>
    /// 생존 여부를 표현하는 변수
    /// </summary>
    bool isAlive = true;

    /// <summary>
    /// 적의 HP를 get/set할 수 있는 프로퍼티
    /// </summary>
    public int HP
    {
        get => hp;          // 읽기는 public
        private set         // 쓰기는 private
        {
            hp = value;
            if (hp < 1)      // 0이되면
            {
                OnDie();    // 사망 처리 수행
            }
        }
    }

    /// <summary>
    /// 자신이 죽었음을 알리는 델리게이트(int : 자신의 점수)
    /// </summary>
    public Action<int> onDie;

    protected override void OnEnable()
    {
        base.OnEnable();
        OnReset();
    }

    private void Update()
    {
        OnMoveUpdate(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP--;   // 부딪칠 때마다 HP감소(적끼리는 부딪치지 않는다)
    }

    protected virtual void OnReset()
    {
        HP = maxHP;
        isAlive = true;
        DisableTimer(lifeTime);
    }

    /// <summary>
    /// Enemy의 종류별로 이동처리를 하는 함수(기본적으로 왼쪽으로만 이동)
    /// </summary>
    /// <param name="deltaTime">Time.deltaTime</param>
    protected virtual void OnMoveUpdate(float deltaTime)
    {
        transform.Translate(deltaTime * moveSpeed * -transform.right, Space.World); // 기본 동작은 왼쪽으로 계속 이동하기
    }

    /// <summary>
    /// 적이 터질 때 실행될 함수
    /// </summary>
    void OnDie()
    {
        if (isAlive) // 살아있을 때만 죽을 수 있음
        {
            isAlive = false;            // 죽었다고 표시
            onDie?.Invoke(point);       // 죽었다고 등록된 객체들에게 알리기(등록된 함수 실행)

            Factory.Instance.GetExplosion(transform.position);

            DisableTimer();     // 자신을 비활성화 시키기
        }
    }
}
