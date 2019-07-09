using System.Collections;
using UnityEngine;

public class SimpleClip : MonoBehaviour
{
    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.167f);
        Destroy(gameObject);
    }

    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }

}//class