using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimationController : PlayerFunctionBase
{
    public override string Name { get { return "AnimationController"; } }

    [SerializeField] Animator m_animator;

    [SerializeField] Transform MagneticFieldGUI;


    [SerializeField] Animator runAnimator;

    private bool m_isVertigo = false;

    FMOD.Studio.EventInstance runEvent;

    public override void PlayerInit()
    {
        if (!m_animator) m_animator = GetComponent<Animator>();
        Player.OnJump += OnJump;
        Player.OnGround += OnGround;

        Player.OnBeHit += OnBeHit;

        if (Player.FunctionBases.ContainsKey("Attack"))
        {
            AttackBase attack = Player.FunctionBases["Attack"] as AttackBase;
            attack.AttackTime.OnStart += OnAttackStart;
            attack.AttackTime.OnTimeOut += OnAttackStop;
            float r = (attack.collider as CircleCollider2D).radius;
            MagneticFieldGUI.localScale = new Vector3(r, r, r);
        }


        if (Player.FunctionBases.ContainsKey("VertigoAction"))
        {
            VertigoAction vertigoAction = Player.FunctionBases["VertigoAction"] as VertigoAction;
            vertigoAction.VertigoAct += OnVertigo;
        }

        runEvent = AudioController.Instance.CreatEvent("PaoBu1");
        defenceEvent = AudioController.Instance.CreatEvent("PaoBu1");
    }

    private void OnBeHit(DamageBase damage)
    {
        m_animator.SetTrigger("blood");
    }


    void OnAttackBeDefence()
    {
        AudioController.Instance.CreatEvent("ciChangFangYu").start();
    }

    // Update is called once per frame
    void Update()
    {

        float inputDir = Input.GetAxis("Move" + Player.ID);

        if (m_isVertigo)
        {
            inputDir = 0.0f;
        }
        else
        {
            if (inputDir < -0.3) Player.transform.localScale = new Vector3(-1, 1, 1);
            if (inputDir > 0.3) Player.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Mathf.Abs(inputDir) >= 0.3)
        {
            m_animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

            runEvent.start();
        }
        else
        {
            runEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }


        m_animator.SetBool("Defence", Player.IsDefence);
        runAnimator.SetBool("OnGround", Player.IsOnGround);
        runAnimator.SetFloat("RunSpeed", Mathf.Abs(Player.PlayerRigidbody2D.velocity.x));
    }

    void OnJump(int jumpTime)
    {
        m_animator.SetTrigger("Jump" + jumpTime);
        switch (jumpTime)
        {
            case 1:
                AudioController.Instance.CreatEvent("TiaoYue1").start();
                break;
            case 2:
                AudioController.Instance.CreatEvent("TiaoYue1").start();
                break;
            default:
                break;
        }

    }

    void OnGround()
    {
        m_animator.SetTrigger("JumpEnd");
    }

    void OnAttackStart() { m_animator.SetBool("Attack", true); AudioController.Instance.CreatEvent("ciChangKongFang").start(); }
    void OnAttackStop() { m_animator.SetBool("Attack", false); }


    void OnVertigo(bool value)
    {
        m_isVertigo = value;
        if (value)
        {
            m_animator.SetTrigger("VertigoTrigger");
        }

        m_animator.SetBool("Vertigo", value);
    }


    FMOD.Studio.EventInstance defenceEvent;

    void OnDefenceStart()
    {

    }

    void OnDefenceStop()
    {

    }
}
