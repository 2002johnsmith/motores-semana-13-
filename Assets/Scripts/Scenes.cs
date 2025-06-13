using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void Cargar()
    {
        SceneManager.LoadScene("Game");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
