using UnityEngine;
using UnityEngine.UI;

public class SphereClickHandler : MonoBehaviour
{
    public Canvas infoCanvas;
    public Text infoText;

    private void Start()
    {
        infoCanvas.enabled = false;
    }

    private void Update()
    {
        // Dokunma algýlama
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            // Sphere'a dokunuldu mu kontrolü
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Sphere'a dokunulduysa, Canvas'i göster
                ShowInfoCanvas();
            }
            else
            {
                // Sphere dýþýnda bir yere dokunulduysa, Canvas'i gizle
                HideInfoCanvas();
            }
        }
    }

    void ShowInfoCanvas()
    {
        infoCanvas.enabled = true;

        infoText.text = "Sphere'e Týklandý!";
    }

    void HideInfoCanvas()
    {
        infoCanvas.enabled = false;
    }
}
