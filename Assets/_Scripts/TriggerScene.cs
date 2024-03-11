using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
