using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

    private Renderer renderer;
    private Animator animator;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        GetComponent<Renderer>().material.color = color;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animasi
            animator.SetTrigger("hit");

            //playsfx
            audioManager.PlaySFXBumper(collision.transform.position);

            //playvfxBumper
            vfxManager.PlayVFXBumper(collision.transform.position);

            //score add
            scoreManager.AddScore(score);
        }
    }
}
