using UnityEngine;
using UnityEngine.UI;

public class PauseMenuPop : MonoBehaviour
{
    public GameObject PauseMenuUI;

    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    public void PauseMenuShow()
    {
        PauseMenuUI.SetActive(true);

    }
}
