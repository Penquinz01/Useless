using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Laddooes;
    [SerializeField] GameObject Input;
    [SerializeField] GameObject PopUp;

    public void FirstNext()
    {
        Laddooes.SetActive(false);
        Input.SetActive(true);
    }
    public void SecondNext() { 
        Input.SetActive(false);
        PopUp.SetActive(true);
    }
    public void ThirdNext()
    {
        SceneManager.LoadScene(1);
    }
}
