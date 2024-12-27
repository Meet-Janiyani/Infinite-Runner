using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] float shakeOffset;
    AudioSource audioSource;
    CinemachineImpulseSource cis;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cis=GetComponent<CinemachineImpulseSource>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        CameraEffect();
        CameraFX(collision);
    }

    private void CameraEffect()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeOffset;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cis.GenerateImpulse(shakeIntensity);
        Debug.Log("Camera Shake");
    }

    private void CameraFX(Collision collision)
    {
        ContactPoint cp= collision.contacts[0];
        ps.transform.position = cp.point;
        ps.Play();
        audioSource.Play();
    }
}
