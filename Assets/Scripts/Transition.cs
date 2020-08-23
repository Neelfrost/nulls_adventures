using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(StartLoadingNext());
    }

    public void LoadLevel(int Level)
    {
        StartCoroutine(StartLoading(Level));
    }

    private IEnumerator StartLoadingNext()
    {
        _animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        GameManager.Instance.LoadNext();
    }

    private IEnumerator StartLoading(int Level)
    {
        _animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        GameManager.Instance.LoadScene(Level);
    }
}
