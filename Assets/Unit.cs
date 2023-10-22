using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool isAlly = true;  // Marcar si la unidad es aliada
    public float attackRange = 2.0f;  // Rango de ataque
    public int attackDamage = 10;  // Daño del ataque
    public Transform attackPoint; // Punto de ataque, puedes configurarlo en el Inspector.

    public void Move(Vector3 destination)
    {
        // Implementa aquí la lógica de movimiento de la unidad hacia la posición de destino.
        // Utiliza "moveSpeed" para controlar la velocidad del movimiento.
    }

    public void Attack(GameObject target)
    {
        // Implementa aquí la lógica de ataque.
        // Puedes usar "attackDamage" y "weaponName" para determinar el daño y el tipo de arma.
        // "attackPoint" es el punto desde el que se origina el ataque.
        // Puedes realizar un raycast desde "attackPoint" hacia el objetivo para determinar si golpea al enemigo.
    }
}