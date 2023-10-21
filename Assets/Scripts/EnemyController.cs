using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
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
    
    
    

    void Start()
    {
        unidadE = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        unidadE.updateRotation = false;

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
    }
    public void Perseguir()
    {
        destino = Unit.position;
        if (Unit.gameObject.CompareTag("Unit"))
        {
            Unit.gameObject.GetComponent<UnitController>().Kill();
            Debug.Log("Seen");
            unidadE.SetDestination(transform.position);
            transform.LookAt(destino);

        }
        

        
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

}
