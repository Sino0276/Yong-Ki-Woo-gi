using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        Managers.Sound.SetBGM("Sound/BGM/BGM1");
        Managers.Sound.PlayBGM();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Managers.Sound.PlaySFX("Sound/SFX/Jump");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Managers.Sound.PlaySFX("Sound/SFX/Attack");
        }
    }
}
