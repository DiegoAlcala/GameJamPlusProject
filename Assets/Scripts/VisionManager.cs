using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionManager : MonoBehaviour
{

    public static VisionManager instance;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    public Transform Unit;
}
