using UnityEngine;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    [SerializeField] private Image _finishUI;
    [SerializeField] private CameraZoomController _cameraZoomController;
    [SerializeField] private CameraPanController _cameraPanController;
    [SerializeField] private Animator   _animatorDodik;

    [SerializeField] GameObject[] _enablesGameObjects;

    [ContextMenu("Finish")]
    public void Finish()
    {
        _cameraZoomController.ZoomToPlayer();
        _cameraZoomController.enabled = false;
        _cameraPanController.ToDodik();
        _cameraPanController.enabled = false;
        _animatorDodik.SetBool("Extented", true);
        _finishUI.gameObject.SetActive(true);
        for (int i = 0; i < _enablesGameObjects.Length; i++)
        {
            _enablesGameObjects[i].SetActive(false);
        }
    }


}
