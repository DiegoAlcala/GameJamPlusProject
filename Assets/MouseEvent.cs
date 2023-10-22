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
            // Puedes implementar la lógica de cambio de personaje aquí.
        }

        if (isEnemy)
        {
            // Selecciona al enemigo para futuras acciones.
            // Puedes implementar la lógica de selección de enemigos aquí.
        }

        if (hasWeapon)
        {
            // Recoge el arma si se hace clic en el objeto.
            // Puedes implementar la lógica de recogida de armas aquí.
        }

        if (hasCollectible)
        {
            // Recoge el coleccionable si se hace clic en el objeto.
            // Puedes implementar la lógica de recogida de coleccionables aquí.
        }

        if (IsDoor)
        {
            // Recoge el coleccionable si se hace clic en el objeto.
            // Puedes implementar la lógica de recogida de coleccionables aquí.
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Desactiva cualquier efecto visual de resaltado al salir del objeto.
    }
}
