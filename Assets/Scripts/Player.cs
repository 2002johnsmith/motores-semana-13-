using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private float moveDuration = 0.25f;

    private void OnEnable()
    {
        InputReader.OnMove += Mover;
    }

    private void OnDisable()
    {
        InputReader.OnMove -= Mover;
    }

    private void Mover(Vector2 direccion)
    {
        Vector3 moveDir = new Vector3(direccion.y, 0, direccion.x);
        Vector3 destino = transform.position + moveDir * moveDistance;

        transform.DOMove(destino, moveDuration).SetEase(Ease.OutSine);
    }
}
