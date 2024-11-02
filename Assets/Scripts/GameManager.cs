using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    [SerializeField] GameObject Trapped;
    [SerializeField] GameObject Hint;


    public void Awake()
    {
        Instance = this;
        StartCoroutine(WaitHint());
    }
    public void Start()
    {
        Trapped.SetActive(false);
    }
    public void Trap()
    {
        Trapped.SetActive(true);
        StartCoroutine(WaitTrap(3));
    }
    IEnumerator WaitTrap(float s)
    {
        yield return new WaitForSeconds(s);
        Trapped.SetActive(false);
    }
    public void LastScene()
    {
        SceneManager.LoadScene(2);
    }
    IEnumerator WaitHint()
    {
        yield return new WaitForSeconds(2);
        Hint.SetActive(false);
    }
}
