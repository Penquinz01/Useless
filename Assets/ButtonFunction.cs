using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    private bool _active = true;
    private Button button;

    public void Awake()
    {
        button = GetComponent<Button>();
    }
    public void OnClick()
    {
        _active =!_active;
        button.interactable = _active;
    }
}
