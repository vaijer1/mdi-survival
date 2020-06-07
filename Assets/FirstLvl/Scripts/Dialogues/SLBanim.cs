using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLBanim : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim.SetBool("SLBopen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim.SetBool("SLBopen", false);
        dm.EndDialogue();
    }

}