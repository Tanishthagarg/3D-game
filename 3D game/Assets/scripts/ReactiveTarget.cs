using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private Animator _anim;

     void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void ReactToHit()
    {
        Wander behavior = GetComponent<Wander>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
         _anim.SetFloat("Speed", 0);
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
