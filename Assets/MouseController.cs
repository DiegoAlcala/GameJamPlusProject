using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
        [SerializeField]
        private GameObject selectedAlly = null;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.collider.gameObject;

                    // Si el jugador hace clic en un aliado, selecciónalo como el personaje actual
                    if (hitObject.CompareTag("Unit"))
                    {
                        SelectAlly(hitObject);
                    }
                    // Si ya hay un aliado seleccionado, intenta atacar a un enemigo
                    else if (selectedAlly != null && hitObject.CompareTag("Enemy"))
                    {
                        // Llama a la función de ataque del personaje actual
                        selectedAlly.GetComponent<Unit>().Attack(hitObject);
                    }
                }
            }
        }

        void SelectAlly(GameObject ally)
        {
            // Deselecciona cualquier aliado previamente seleccionado
            DeselectAlly();

            // Selecciona al aliado actual
            selectedAlly = ally;

            // Puedes agregar aquí lógica adicional, como resaltar la unidad seleccionada
        }

        void DeselectAlly()
        {
            // Si hay un aliado seleccionado, deseléccionalo
            if (selectedAlly != null)
            {
                // Puedes quitar aquí cualquier efecto de resaltado o realimentación visual
                selectedAlly = null;
            }
        }
    }
