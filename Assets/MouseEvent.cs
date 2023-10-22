using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MouseEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Player")]
    public GameObject characterStats;
    private bool isSelectable = false;
    private bool isSelected = false;
    private bool isEnemy = false;
    private bool hasWeapon = false;
    private bool hasCollectible = false;
    private bool IsDoor = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSelectable)
        {
            // Muestra un efecto visual de resaltado para indicar que el objeto es seleccionable.
        }

        if (isSelected)
        {
            // Cambia el personaje actual si se hace clic en el objeto.
            // Puedes implementar la l�gica de cambio de personaje aqu�.
        }

        if (isEnemy)
        {
            // Selecciona al enemigo para futuras acciones.
            // Puedes implementar la l�gica de selecci�n de enemigos aqu�.
        }

        if (hasWeapon)
        {
            // Recoge el arma si se hace clic en el objeto.
            // Puedes implementar la l�gica de recogida de armas aqu�.
        }

        if (hasCollectible)
        {
            // Recoge el coleccionable si se hace clic en el objeto.
            // Puedes implementar la l�gica de recogida de coleccionables aqu�.
        }

        if (IsDoor)
        {
            // Recoge el coleccionable si se hace clic en el objeto.
            // Puedes implementar la l�gica de recogida de coleccionables aqu�.
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Desactiva cualquier efecto visual de resaltado al salir del objeto.
    }
}
