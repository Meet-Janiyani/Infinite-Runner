using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 120f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier=5f;

    CinemachineCamera cc;

    void Awake()
    {
        cc = GetComponent<CinemachineCamera>();    
    }

    public void ChangeCameraFOV(float moveSpeed)
    {
        StartCoroutine(CameraRoutine(moveSpeed));
    }

    IEnumerator CameraRoutine(float moveSpeed)
    {
        float startPOV =cc.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startPOV+moveSpeed*zoomSpeedModifier,minFOV,maxFOV);

        float elapsedTime = 0f;
        while(elapsedTime < zoomDuration)
        {
            elapsedTime+= Time.deltaTime;
            cc.Lens.FieldOfView = Mathf.Lerp(startPOV,targetFOV,elapsedTime/zoomDuration);
            yield return null;
        }
        cc.Lens.FieldOfView = targetFOV;
    }
}
