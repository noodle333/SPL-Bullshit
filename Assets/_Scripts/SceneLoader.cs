using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject transitionImage;
    [SerializeField] private bool stopStartTransition;

    private void Start()
    {
        anim = GetComponent<Animator>();
        transitionImage.SetActive(true);
        if (!stopStartTransition)
        {
            anim.SetBool("TransitionStart", true);
            StartCoroutine(TransitionImageFinish());
        }
    }

    public void StartLoadScene()
    {
        StartCoroutine(LoadScene(sceneToLoad));
    }

    public void StartLoadSceneMenu(string sceneToLoad)
    {
        StartCoroutine(LoadScene(sceneToLoad));
    }

    private IEnumerator LoadScene(string s)
    {
        anim.SetBool("TransitionEnd", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(s);
        anim.SetBool("TransitionEnd", false);
    }

    private IEnumerator TransitionImageFinish()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("TransitionStart", false);
    }
}
