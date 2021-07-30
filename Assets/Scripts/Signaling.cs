using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
             _signal.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
             _signal.Stop();
    }
}
