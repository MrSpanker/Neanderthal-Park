using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    [SerializeField] private CameraZoomController _cameraZoomController;
    [SerializeField] private CameraPanController _cameraPanController;
    [SerializeField] private Animator   _animatorDodik;
    [SerializeField] private Vector3 _toTarget;
    [SerializeField] private Quaternion _toTargetRotation;

    [SerializeField] private GameObject _dodik;

    [SerializeField] GameObject[] _disablesGameObjects;
    [SerializeField] GameObject[] _enablesGameObjects;

    [ContextMenu("Finish")]
    public void Finish()
    {
        _cameraZoomController.ZoomToPlayer();
        _cameraPanController.ToDodik(_toTarget);

        _dodik.transform.rotation = _toTargetRotation;
        _cameraZoomController.enabled = false;
        _cameraPanController.enabled = false;
        for (int i = 0; i < _enablesGameObjects.Length; i++)
        {
            _enablesGameObjects[i].SetActive(true);
        }
        for (int i = 0; i < _disablesGameObjects.Length; i++)
        {
            _disablesGameObjects[i].SetActive(false);
        }
        _animatorDodik.SetBool("Extented", true);
    }


}
