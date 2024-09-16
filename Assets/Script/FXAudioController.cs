using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXAudioController : MonoBehaviour
{
    public GameObject vfxAudioSource;

    private void PlayVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(vfxAudioSource,spawnPosition, Quaternion.identity);
    }

}
