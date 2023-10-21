using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SucessLevel : MonoBehaviour
{
    [Serializable]
    public class SucessLevelClass : UnityEvent {}


    [FormerlySerializedAs("LastLevel")]
    [SerializeField]
    public SucessLevelClass sucessLevel = new SucessLevelClass();
    
    public int index;
    Scene currentScene;
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Unit")){
            currentScene =  SceneManager.GetActiveScene();
            index = currentScene.buildIndex;

            if(index == 3)
            {
                sucessLevel.Invoke();
            }
            else
            {
                GameManager.Instance.GetComponent<Loader>().SubirNivel();
            }
        }
    }
}
