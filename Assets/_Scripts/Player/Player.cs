using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Player : Entity
{

    [Header("Attack details")]
    public Vector2[] attackMovement;
    

    public bool isBusy { get; private set; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;
    public bool canDoubleJump;
    public float jumpStartTime;
    public float jumpTime;
    public bool isJumping;


    //[Header("Dash info")]
    //[SerializeField] private float dashCooldown;
    //private float dashUsageTimer;
    //public float dashSpeed;
    //public float dashDuration;
    //public float dashDir { get; private set; }

    
    public PlayerAbilityTracker abilities;

    public static Player instance;

    public string areaTransitionName;



    #region States
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerWallSlideState WallSlide { get; private set; }
    public PlayerWallJumpState WallJump { get; private set; }
    //public PlayerDashState DashState { get; private set; }
    public PlayerShotState ShotState { get; private set; }
    public PlayerPrimaryAttackState PrimaryAttack { get; private set; }

    public PlayerDeadState DeadState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        // Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        //DashState = new PlayerDashState(this, StateMachine, "Dash");
        WallSlide = new PlayerWallSlideState(this, StateMachine, "WallSlide");
        WallJump = new PlayerWallJumpState(this, StateMachine, "Jump");
        ShotState = new PlayerShotState(this, StateMachine, "Shot");
        DeadState = new PlayerDeadState(this, StateMachine, "Die");

        PrimaryAttack = new PlayerPrimaryAttackState(this, StateMachine, "Attack");

        DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        abilities = GetComponent<PlayerAbilityTracker>();
        StateMachine.Initialize(IdleState);
    }

    

    protected override void Update()
    {
        base.Update();
        StateMachine.CurrentState.Update();
        //CheckForDashInput();
        // Debug.Log(StateMachine.CurrentState);
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void AnimationTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    public void Fire() => this.FireProjectile();

/*
    private void CheckForDashInput()
    {
        if (IsWallDetected())
            return;

        dashUsageTimer -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0 && abilities.canDash)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;


            StateMachine.ChangeState(DashState);
        }
    }
    */
    public PlayerState GetPlayerState() => StateMachine.CurrentState;

    public void JumpButton()
    {
        if (IsGroundDetected())
        {
            StateMachine.ChangeState(JumpState);
        }
    }

    public override void Die()
    {
        base.Die();

        StateMachine.ChangeState(DeadState);
    }

    #region Shot

    public void FireProjectile()
    {
        {
            if (!facingRight)
            {
                shotToFire.transform.localScale = new Vector3(-1f, 1f, 1f);
                chargedShot.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                shotToFire.transform.localScale = Vector3.one;
                chargedShot.transform.localScale = Vector3.one;
            }

            if (chargeTime < 1)
            {
                Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir =
                new Vector2(transform.localScale.x, 0f);
            }
            else
            {
                Instantiate(chargedShot, shotPoint.position, shotPoint.rotation).moveDir =
                new Vector2(transform.localScale.x, 0f);
                chargeTime = 0;
                isCharging = false;
            }
        }
    }

    #endregion
}
