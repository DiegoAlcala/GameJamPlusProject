using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType
    {
        Shooter,
        Melee
    }
    public EnemyType enemyType;
    private UnityEngine.AI.NavMeshAgent unidadE;
    public Transform Unit;
    public Transform[] point;
    public LayerMask terreno;
    public Vector3 destino;
    public bool destinoSet;
    public float tiempoEspera;
    private int siguienteDestino;
    public float contador;
    public ThirdPersonCharacter character;

    public float timePassed;
    public float attackTime;
    public float attackRange;


    void Start()
    {
        unidadE = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        unidadE.updateRotation = false;
        InitializeEnemyBehavior();

    }
    void InitializeEnemyBehavior()
    {
        switch (enemyType)
        {
            case EnemyType.Shooter:
                // Configura el comportamiento del enemigo tirador.
                break;
            case EnemyType.Melee:
                // Configura el comportamiento del enemigo cuerpo a cuerpo.
                break;
        }
    }

    void Update()
    {

        if (GameManager.Instance.gameState == GameManager.GameState.Idle)
        {
            return;
        }
        
        if (unidadE.remainingDistance > unidadE.stoppingDistance)
        {
            character.Move(unidadE.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }

        // Si el jugador está dentro del rango de ataque, ataca.
    }
    public void Perseguir()
    {
        if (Unit.gameObject.CompareTag("Unit") && timePassed >= attackTime)
        {

            //Unit.gameObject.GetComponent<UnitController>().Kill();
            Debug.Log("Seen");
            unidadE.SetDestination(Unit.gameObject.transform.position);
            destino = Unit.position;
            transform.LookAt(destino);
        float distanceToPlayer = Vector3.Distance(transform.position, Unit.position);

        // Comprueba si el jugador está dentro del rango de ataque.
        if (distanceToPlayer <= attackRange)
        {
                Attack();
            // El jugador está dentro del rango de ataque.
            // Puedes realizar acciones como iniciar un ataque o activar animaciones aquí.
            }


        }        
    }
    public void Attack()
    {
        //detener el personaje 
        Debug.Log("Active la animacion");
        //Animacion de atacar
        //animator.SetTrigger("attack");
        timePassed = 0;
        Invoke("Perder", 2f);
        //audioManager.PlayAudioClip(audioManager.RandomiseSounds(attackBossSounds), audioSourceAttacks);
    }
    public void Perder()
    {
        Debug.Log("Pantalla de derrota");
        //Unit.gameObject.GetComponent<UnitController>().Kill();
    }

    public void patrullar()
    {
        
        if(contador < tiempoEspera)
        {
            contador = contador + 1* Time.deltaTime;
        }
        if (contador >= tiempoEspera)
        {
            unidadE.SetDestination(point[siguienteDestino].transform.position);
        }
        Vector3 distanciaDestino = point[siguienteDestino].transform.position - this.transform.position;
        if (Mathf.Abs(distanciaDestino.x) < 0.1f && Mathf.Abs(distanciaDestino.z) < 0.1f)
        {
            contador = 0;
            if (siguienteDestino < point.Length - 1)
            {
                siguienteDestino++;
            }
            else if(siguienteDestino == point.Length - 1)
            {
                siguienteDestino = 0;
            }
        }

    }
    bool IsPlayerInAttackRange()
    {
        // Verifica si el jugador está dentro del rango de ataque.
        return Vector3.Distance(transform.position, Unit.position) <= attackRange;
    }

}
