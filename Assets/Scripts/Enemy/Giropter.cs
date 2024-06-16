using UnityEngine;

public class Giropter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] ParticleSystem _particlesDead;
    [SerializeField] private ParticleSystem _particleHit;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private DodikComponent _dodik;
    [SerializeField] private Collider _giroCollider;


    [SerializeField] int _healthGiro;
    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        Vector3 toDodik = _dodik.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toDodik);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 2f, 5f), transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {
            Damage();
        }

    }

    private void Damage()
    {
        Collider currentCollider;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Ray ray = _camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            currentCollider = hit.collider;
            if (currentCollider == _giroCollider)
            {
                _healthGiro--;
                _particleHit.Play();
                if (_healthGiro < 0)
                {
                    _particlesDead.gameObject.SetActive(true);
                    _particlesDead.Play();
                    _particlesDead.transform.parent = null;
                    Destroy(gameObject);
                }
            }
        }
    }
}
