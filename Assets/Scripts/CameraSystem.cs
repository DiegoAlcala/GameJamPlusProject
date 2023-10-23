using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Camera;
    public bool rotateCam;
    public bool isActive;
    public Vector2 boundaries;
    public float moveSpeed = 10f;
    private float fov = 60;
    private float fovMax = 100;
    private float fovMin = 10;
    private int edgeMoveSize = 30;
    public float maxMoveMagnitude;

    private void Update() 
   {
      if(isActive)
      {
         CameraMovement();
      }

      if (rotateCam == false)
      {
         CameraZoom();
      }

      if (rotateCam == true)
      {
         CameraRotation();
      }
   }

    private void CameraMovement() 
    {
        Vector3 inputDir = new Vector3(0,0,0);

        if(Input.mousePosition.x < edgeMoveSize) 
        {
            inputDir.x = -1f;
        }
    
        if(Input.mousePosition.y < edgeMoveSize) 
        {
            inputDir.z = -1f;
        }
        
        if(Input.mousePosition.x > Screen.width - edgeMoveSize) 
        {
            inputDir.x = +1f;
        }
        
        if(Input.mousePosition.y > Screen.height - edgeMoveSize) 
        {
            inputDir.z = +1f;
        }

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        moveDir = Vector3.ClampMagnitude(moveDir, maxMoveMagnitude); // Limita el movimiento

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

   private void CameraRotation() //arreglar rotacion, tiene un pumping bastante fuerte
   {
      float rotateSpeed = 300f;
      float rotateDir= 0f;
      if(Input.mouseScrollDelta.y > 0) rotateDir = +1f; 
      if(Input.mouseScrollDelta.y < 0) rotateDir = -1f; 
      transform.eulerAngles += new Vector3(0, rotateDir*rotateSpeed*Time.deltaTime, 0);

      rotateDir= Mathf.Lerp(rotateDir, rotateDir, Time.deltaTime * rotateSpeed);

   }

   private void CameraZoom()
   {
      if(Input.mouseScrollDelta.y > 0)
      {
         fov -= 5;
      }
      if(Input.mouseScrollDelta.y < 0)
      {
         fov += 5;
      }

      fov = Mathf.Clamp(fov, fovMin,fovMax);

      float zoomSpeed = 10f;

      Camera.m_Lens.FieldOfView = Mathf.Lerp(Camera.m_Lens.FieldOfView, fov, Time.deltaTime * zoomSpeed);
      //Camera.m_Lens.FieldOfView = fov;

   }


}
