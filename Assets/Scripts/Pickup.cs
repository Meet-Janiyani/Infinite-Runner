using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0f,rotationSpeed*Time.deltaTime,0f);     
    }

    protected abstract void OnPickup();
}
