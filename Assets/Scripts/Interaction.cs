using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interaction : MonoBehaviour
{
    public bool interactOnTrigger = true;
    public bool destroyOnInteract = true;

    public virtual void BeforeInteract()
    {

    }

    public virtual void MainInteract()
    {

    }

    public virtual void EndInteract()
    {
        if (destroyOnInteract)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Interact()
    {
        BeforeInteract();
        MainInteract();
        EndInteract();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interactOnTrigger && Utils.IsPlayerGameObject(other.gameObject))
        {
            Interact();
        }
    }
}
