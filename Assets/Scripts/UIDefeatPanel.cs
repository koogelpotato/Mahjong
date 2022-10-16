using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDefeatPanel : MonoBehaviour
{
    [SerializeField]
    private Container _container;
    private void OnEnable()
    {
        _container.PlayerDefeat += EnablePanel;
    }
    private void EnablePanel()
    {
        gameObject.SetActive(true);
        _container.PlayerDefeat -= EnablePanel;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }


}
