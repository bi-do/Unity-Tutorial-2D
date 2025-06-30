using System.Collections;
using TMPro;
using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    private Animator animator;
    private float PushForce = 140f;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Player"))
        // {
            StartCoroutine(PushCharacter(collision));
        // }
    }

    IEnumerator PushCharacter(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().AddForceY(this.PushForce, ForceMode2D.Impulse);
        this.animator.SetTrigger("Push");
        yield return null;
    }

}
