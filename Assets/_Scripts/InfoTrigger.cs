using UnityEngine;
using TMPro;

public class InfoTrigger : MonoBehaviour
{
    [SerializeField] private string infoTitle;
    [SerializeField] private string description;

    [SerializeField] private GameObject infoCanvas;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            infoCanvas.SetActive(true);
            titleText.text = infoTitle;
            descriptionText.text = description;
        }
    }

    //test new commit


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            infoCanvas.SetActive(false);
        }
    }
}
