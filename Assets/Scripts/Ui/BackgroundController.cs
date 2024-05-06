using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private MoveBackground[] backgrounds;

    private void Update()
    {
        if (!GameManager.Instance.isPlaying)
        {
            foreach(var background in backgrounds)
            {
                background.enabled = false;
            }
        }else
        {
            foreach(var background in backgrounds)
            {
                background.enabled = true;
            }
        }
    }
}
