using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class UnitController : MonoBehaviour
{
    public LayerMask terreno;
    public NavMeshAgent unidad;    
    private Ray ruta; 
    private RaycastHit destino;
    public bool isAlive;
    public bool isAttack;
    public bool isMoving;
    public ThirdPersonCharacter character;

    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Idle)
        {
            return;
        }
        
        character.UpdateAnimator();
       
        if (Input.GetMouseButtonDown(0) && isAlive && !isAttack)
        {
            ruta = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ruta,out destino,100,terreno))
            {
                unidad.SetDestination(destino.point);
                isMoving = true;
            }
        }

        //if(pausa)
        //{
        //    unidad.SetDestination(transform.position);
        //}
        
        if (unidad.remainingDistance > unidad.stoppingDistance && isMoving)
        {
            character.Move(unidad.desiredVelocity, false, false);
        }
        else
        {
            isMoving = false;
            character.Move(Vector3.zero, false, false);
        }

        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            Attack();
        }
    }

    public void Attack()
    {
        isAttack = true;
        character.Attack();
    }

    public void Kill()
    {
        if (isAlive)
        {
            isAlive = false;
            GameManager.Instance.GameOver();
            unidad.SetDestination(transform.position);
        }
    }
}
