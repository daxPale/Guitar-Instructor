using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private float minFov = 7f;
    [SerializeField] private float maxFov = 40f;
    [SerializeField] private float sensitivity = 15;
    [SerializeField] private float damping = 3;

    public Transform targetHand;
    public Transform targetBody;
    
    private CinemachineVirtualCamera _followCamera;
    private Animator _animator;
    private Quaternion _rotation;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _followCamera = GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>();
        _rotation = Quaternion.LookRotation(_followCamera.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        HandleZoom();

        if (!SoundManager.IsPLaying())
        {
            HandleInput();
        }
    }

    private void HandleZoom()
    {
        float fov = _followCamera.m_Lens.FieldOfView;
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        fov -= scrollValue * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        _followCamera.m_Lens.FieldOfView = fov;

        if (scrollValue > 0 || _followCamera.m_Lens.FieldOfView == minFov)
            _rotation = Quaternion.LookRotation(targetHand.position - _followCamera.transform.position);
        else if (scrollValue < 0)
            _rotation = Quaternion.LookRotation(targetBody.position - _followCamera.transform.position);

        _followCamera.transform.rotation = Quaternion.Slerp(_followCamera.transform.rotation, _rotation, Time.deltaTime * damping);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("A_Chord");
            SoundManager.PlayChordSound(SoundManager.Chord.A);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _animator.SetTrigger("C_Chord");
            SoundManager.PlayChordSound(SoundManager.Chord.C);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("D_Chord");
            SoundManager.PlayChordSound(SoundManager.Chord.D);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("E_Chord");
            SoundManager.PlayChordSound(SoundManager.Chord.E);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            _animator.SetTrigger("G_Chord");
            SoundManager.PlayChordSound(SoundManager.Chord.G);
        }
    }

    private void ResetTriggers()
    {
        foreach (var trigger in _animator.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
            {
                _animator.ResetTrigger(trigger.name);
            }
        }
    }
}
