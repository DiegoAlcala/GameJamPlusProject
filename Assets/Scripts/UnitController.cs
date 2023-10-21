using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class UnitController : MonoBehaviour
{
    public LayerMask terreno;
    private NavMeshAgent unidad;    
    private Ray ruta; 
    private RaycastHit destino;
    public bool isAlive = true;
    public bool pausa;
    public ThirdPersonCharacter character;

    void Start()
    {
        unidad = this.GetComponent<NavMeshAgent>();
        unidad.updateRotation = false;
    }

    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Idle)
        {
            return;
        }
        if (GameManager.Instance.gameState == GameManager.GameState.Pause)
        {
            pausa = true;
        }
        else
        {
            pausa = false;
        }
        if (Input.GetMouseButtonDown(0) && isAlive && !pausa)
        {
            ruta = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ruta,out destino,100,terreno))
            {
                unidad.SetDestination(destino.point);

            }
        }
        if(pausa)
        {
            unidad.SetDestination(transform.position);
        }
        if (unidad.remainingDistance > unidad.stoppingDistance)
        {
            character.Move(unidad.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
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
