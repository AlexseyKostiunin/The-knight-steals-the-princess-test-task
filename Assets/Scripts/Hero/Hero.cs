using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PolygonCollider2D))]
public class Hero : MonoBehaviour
{
    private int _numberStolenPrincesses;

    public event UnityAction<int> PrincessesReceived;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Princess princess))
        {
            _numberStolenPrincesses++;

             PrincessesReceived?.Invoke(_numberStolenPrincesses);

             Destroy(collision.gameObject);
        }
    }
}
