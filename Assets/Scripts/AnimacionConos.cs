using UnityEngine;
using DG.Tweening;
using System.Collections;

public class AnimacionConos : MonoBehaviour
{
    [SerializeField] private Transform cono1;
    [SerializeField] private Transform cono2;
    [SerializeField] private Transform cono3;
    [SerializeField] private GameObject esferaPrefab;
    [Header("cono 1")]
    [SerializeField] private float durationBullet;
    [SerializeField] private float distance;
    [Header("cono 2")]
    [SerializeField] private float velocityRotate;
    [Header("cono 3")]
    [SerializeField] private float distancemovement;

    void Start()
    {
        // cono 1
        StartCoroutine(LanzarEsferasCono1());

        // cono 2
        cono2.DOLocalRotate(new Vector3(0, velocityRotate, 0), 1f, RotateMode.LocalAxisAdd)
             .SetEase(Ease.Linear)
             .SetLoops(-1);

        // cono 3
        float zOriginal = cono3.position.z;
        cono3.DOMoveZ(zOriginal + distancemovement, 1f)
             .SetEase(Ease.InOutSine)
             .SetLoops(-1, LoopType.Yoyo);
    }
    IEnumerator LanzarEsferasCono1()
    {
        while (true)
        {
            GameObject esfera = Instantiate(esferaPrefab, cono1.position + cono1.forward, Quaternion.identity);

            Vector3 destino = esfera.transform.position + cono1.forward * distance;
            esfera.transform.DOMove(destino, durationBullet).SetEase(Ease.Linear);

            Destroy(esfera, 2f);

            yield return new WaitForSeconds(2.5f);
        }
    }
}
