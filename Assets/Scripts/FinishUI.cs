using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    [SerializeField] private Image _finishUI;
    [SerializeField] private CameraZoomController _cameraZoomController;
    [SerializeField] private CameraPanController _cameraPanController;
    [SerializeField] private Animator   _animatorDodik;
    [SerializeField] private Vector3 _cameraPosition;
    [SerializeField] GameObject _stateMachine;

    [ContextMenu("Finish")]
    public void Finish()
    {
        _cameraZoomController.ZoomToPlayer();
        _cameraZoomController.enabled = false;
        _cameraPanController.transform.position = _animatorDodik.transform.position + _cameraPosition;
        _cameraPanController.enabled = false;
        _stateMachine.SetActive(false);
        _animatorDodik.SetBool("Extented", true);
    }


}
