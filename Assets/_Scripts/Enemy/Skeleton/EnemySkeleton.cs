using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{
    // State
    private SpriteRenderer spriteRenderer;
    private Color corOriginal;
    private Color corPiscada = new Color(0f, 0.6392f, 1f); // Cor 00A3FF
    public SkeletonIdleState IdleState { get; private set; }
    public SkeletonMoveState MoveState { get; private set; }

    public SkeletonBattleState BattleState { get; private set; }

    public SkeletonAttackState AttackState { get; private set; }

    public int vidaAtual, vidaTotal;
    public bool estaAtordoado;
    public bool estaReinicializado;


    protected override void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        corOriginal = spriteRenderer.color;
        
        System.Random rand = new System.Random();
        vidaTotal = rand.Next(3, 6);
        vidaAtual = vidaTotal;
        
        estaAtordoado = false;
        estaReinicializado = false;
        
        base.Awake();
        IdleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        MoveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        BattleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        AttackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();

        if(vidaAtual <= 0)
        {
            //StartCoroutine(Atordodo());
            Destruido();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!estaReinicializado)
        {
            if (collision.CompareTag("bullet"))
            {
                Atingido();
            }
        }
    }

    private void Atingido()
    {
            PiscadaDeDano();
            vidaAtual--;
    }

    private System.Collections.IEnumerator Atordodo()
    {
        estaAtordoado = true;
        yield return new WaitForSeconds(3f);
        Debug.Log("Atordoado...");
        vidaAtual = vidaTotal;
        estaAtordoado = false;
    }

    private void Reinicializado()
    {
        //troca animação
        GameManager gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
        gameManager.AdicionaRobo();
    }

//TEMPORÁRIO
    private void Destruido()
    {
        GameManager gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
        gameManager.AdicionaRobo();
        gameManager.timer = gameManager.timer + 3.0f; //dando tempo extra
        Destroy(gameObject);
    }



    private void PiscadaDeDano()
    {
        // Altera a cor para a cor de piscada
        StartCoroutine(PiscarCor());

        // Realize outras ações de dano aqui, se necessário
    }

    private System.Collections.IEnumerator PiscarCor()
    {
        // Altera a cor para a cor de piscada
        spriteRenderer.color = corPiscada;

        // Aguarda por um curto período de tempo
        yield return new WaitForSeconds(0.5f);

        // Retorna à cor original gradualmente em menos de meio segundo usando Color.Lerp
        float elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            spriteRenderer.color = Color.Lerp(corPiscada, corOriginal, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Garante que a cor volta exatamente à original
        spriteRenderer.color = corOriginal;
    }

}
