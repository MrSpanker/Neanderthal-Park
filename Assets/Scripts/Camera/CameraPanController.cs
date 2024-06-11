using UnityEngine;
using UnityEngine.UIElements;

namespace Dragoncraft
{
    public class CameraPanController : MonoBehaviour
    {
        [SerializeField] private float _borderSize = 1f;
        [SerializeField] private float _panSpeed = 10f;
        [SerializeField] private Vector2 _panLimit = new Vector2(30f, 35f);
#if UNITY_EDITOR
        [SerializeField] private bool _disableCameraMovement = false;
#endif
        private Vector3 _initialPosition = Vector3.zero;

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (_disableCameraMovement)
                return;
#endif
            UpdatePan();
        }        

        private void UpdatePan()
        {
            Vector3 position = transform.position;

            if (Input.mousePosition.y >= Screen.height - _borderSize || Input.GetKey(KeyCode.W))
            {
                position.z += _panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y <= _borderSize || Input.GetKey(KeyCode.S))
            {
                position.z -= _panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x >= Screen.width - _borderSize || Input.GetKey(KeyCode.D))
            {
                position.x += _panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x <= _borderSize || Input.GetKey(KeyCode.A))
            {
                position.x -= _panSpeed * Time.deltaTime;
            }

            if (position == transform.position)
            {
                return;
            }

            position.x = Mathf.Clamp(position.x, -_panLimit.x + _initialPosition.x, _panLimit.x + _initialPosition.x);
            position.z = Mathf.Clamp(position.z, -_panLimit.y + _initialPosition.z, _panLimit.y + _initialPosition.z);

            transform.position = position;
        }
    }
}