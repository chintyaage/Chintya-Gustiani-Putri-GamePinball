using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    public float score;

    public AudioManager audioManager;
    public ScoreManager scoreManager;
    public VFXManager vfxManager;

    private bool isOn;
    private SwitchState state;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();

            // Play SFX
            audioManager.PlaySFXSwitch(other.transform.position);

            //playvfxSwitch
            vfxManager.PlayVFXSwitch(other.transform.position);
        }
    }

    private void Set(bool active)
    {
        isOn = active;

        if(isOn == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
            scoreManager.AddScore(score);
        }
        else
        {
            Set(true);
            scoreManager.AddScore(score);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

}
