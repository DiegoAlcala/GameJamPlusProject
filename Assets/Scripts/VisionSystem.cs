using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class VisionSystem : MonoBehaviour
{
    public float visionAngle = 45f;
    public float maxVisionDistance = 20f;
    public float nearVisionAngle = 45f;
    public float maxNearVisionDistance = 5f;
    
    public Color visionColor;
    public LayerMask mask;
    public bool Alive;
    
    
    

    [Serializable]
    public class OnUnitDetectClass : UnityEvent {}


    [FormerlySerializedAs("OnDetectUnit")]
    [SerializeField]
    public OnUnitDetectClass m_OnDetectUnit = new OnUnitDetectClass();

    [Serializable]
    public class OnUnitLostClass : UnityEvent {}


    [FormerlySerializedAs("OnLostUnit")]
    [SerializeField]
    public OnUnitLostClass m_OnLostUnit = new OnUnitLostClass();

    private void Update() 
    {
        
        
        Alive = VisionManager.instance.Unit.gameObject.GetComponent<UnitController>().isAlive;
        if (GameManager.Instance.gameState == GameManager.GameState.Idle)
        {
            return;
        }
        Vector3 targetDirection = VisionManager.instance.Unit.position - transform.position;
        float Angle = Vector3.Angle (targetDirection, transform.forward * maxVisionDistance);
        if(Alive)
        {
            if(Angle < visionAngle)
            {
                RaycastHit hit;
            
                if(Physics.Raycast(transform.position, targetDirection, out hit, maxVisionDistance, mask))
                {
                    if(hit.collider.gameObject.layer != null)
                    {
                        if(hit.collider.transform == VisionManager.instance.Unit)
                        {
                            Debug.DrawRay (transform.position, targetDirection, Color.red);

                            m_OnDetectUnit?.Invoke();
                        }
                        else
                        {
                            m_OnLostUnit?.Invoke();
                        }                    
                    }
                }
            }
            else
            {
            m_OnLostUnit?.Invoke();
            }
        }
        else
        {
            return;
        }
    }

}


