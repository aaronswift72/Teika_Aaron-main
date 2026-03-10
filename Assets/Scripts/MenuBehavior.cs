using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public AudioSource source;


    public void goToGame()
    {
        SceneManager.LoadScene("Teika");
        source.Play();
    }

}
