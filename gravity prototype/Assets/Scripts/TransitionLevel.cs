using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionLevel : MonoBehaviour
{
    public Animator fade;

    private void Update()
    {
        if (door.advance)
        {
            door.advance = false;
            StartCoroutine(Fade(SceneManager.GetActiveScene().buildIndex + 1));    
        }
        
    }

    IEnumerator Fade(int index)
    {
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
