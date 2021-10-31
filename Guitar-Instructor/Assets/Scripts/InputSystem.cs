using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!SoundManager.IsPLaying())
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
    }
}
