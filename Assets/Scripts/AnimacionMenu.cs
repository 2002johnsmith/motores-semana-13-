using UnityEngine;
using DG.Tweening;

public class AnimacionMenu : MonoBehaviour
{
    [SerializeField]private RectTransform titulo;
    [SerializeField]private RectTransform botonCargar;
    [SerializeField]private RectTransform botonSalir;

    void Start()
    {
        // titulo
        titulo.anchoredPosition = new Vector2(0, 400);
        titulo.DOAnchorPosY(210f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        titulo.localRotation = Quaternion.Euler(0, 0, -5f);
        titulo.DORotate(new Vector3(0, 0, 5f), 2f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        // carga
        botonCargar.localScale = Vector3.one;
        botonCargar.DOScale(new Vector3(1.1f, 1.1f, 1), 0.5f)
        .SetEase(Ease.InOutSine)
        .SetLoops(-1, LoopType.Yoyo);

        // salir
        Vector2 posicionOriginal = botonSalir.anchoredPosition;
        botonSalir.DOAnchorPosX(posicionOriginal.x + 20f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}

