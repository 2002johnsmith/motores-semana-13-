using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    private Vector3 movement;
    private Rigidbody rb;
    private bool puedeRotar = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

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
        movement = new Vector3(direccion.y, 0, direccion.x);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movement.x * velocidad, rb.linearVelocity.y, movement.z * velocidad);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedeRotar)
        {
            puedeRotar = false;

            Vector3 posicionInicial = transform.position;

            Sequence pirueta = DOTween.Sequence();

            pirueta.Append(transform.DOMoveY(posicionInicial.y + 2f, 0.5f).SetEase(Ease.OutQuad)) 
                  .Join(transform.DORotate(new Vector3(360, 0, 0), 1.5f, RotateMode.FastBeyond360).SetEase(Ease.OutSine)) 
                  .Append(transform.DOMoveY(posicionInicial.y, 0.5f).SetEase(Ease.InQuad)) 
                  .OnComplete(() => puedeRotar = true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("Derrota");
        }
        else if (other.CompareTag("Meta"))
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("Victoria");
        }
    }
}
