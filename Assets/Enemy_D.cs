using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class Enemy_D : MonoBehaviour
{
    [Header("Live")]
    // Variable de vida para todos los enemigos
    [SerializeField] public float health = 3;

    [SerializeField] public GameObject damageText;

    [SerializeField] float resetHeath;
    [SerializeField] float resetSpeed;

    // Variable para el efecto visual cusndo el enemigo sea golpeado
    [SerializeField] GameObject hitVFX;

    // MiniMap Indicator:
    [SerializeField] GameObject miniMapIndicator;

    [Header("Combat")]
    // Tiempo entre los ataques
    public float attackTime = 0.1f;
    // Rango de ataque
    public float attackRange;
    // Rango de movimiento para seguir al jugador
    public float aggroRange;
    public int fuerzaEmpuje = 1;

    protected GameObject player;
    NavMeshAgent agent;
    protected Animator animator;
    protected float timePassed;
    protected float newDestinationCD = 1f;

    public AudioSource audioSourceSFXBoss;
    public AudioClip[] damageBossSounds;


    private void Awake()
    {
        resetHeath = health;
        agent = GetComponent<NavMeshAgent>();
        resetSpeed = agent.speed;
    }
    private void LateUpdate()
    {

        InitializeVariables();
        if (GameManager.Instance.gameState == GameManager.GameState.Idle)
        {
            return;
        }
        if (animator.GetBool("isDeath") == false)
        {
            MoveEnemy();
            AttackEnemy();
            Obser();
        }
    }

    void InitializeVariables()
    {
        //agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

    }

    void MoveEnemy()
    {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);
        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange && animator.GetBool("isAttack") == false)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position * fuerzaEmpuje);
        }

        if (animator.GetBool("isAttack") == true)
        {
            Invoke("activateMovement", 4f);
        }
        newDestinationCD -= Time.deltaTime;
    }
    public void activateMovement()
    {
        animator.SetBool("isAttack", false);
    }
    void Obser()
    {
        //  transform.LookAt(player.transform.position);
        if (player != null)
        {
            Vector3 targetPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.rotation = Quaternion.LookRotation(targetPos - transform.position);
        }
    }

    protected abstract void AttackEnemy();
}
