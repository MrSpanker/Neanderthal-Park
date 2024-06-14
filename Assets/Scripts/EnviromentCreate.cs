using DG.Tweening;
using UnityEngine;

public class EnviromentCreate : MonoBehaviour
{
    Vector3 _scale;
    private void OnEnable()
    {
        _scale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(_scale, 1);

    }
}
