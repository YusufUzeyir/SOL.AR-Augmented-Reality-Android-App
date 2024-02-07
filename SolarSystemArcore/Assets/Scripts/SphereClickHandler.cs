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
        // Dokunma alg�lama
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            // Sphere'a dokunuldu mu kontrol�
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Sphere'a dokunulduysa, Canvas'i g�ster
                ShowInfoCanvas();
            }
            else
            {
                // Sphere d���nda bir yere dokunulduysa, Canvas'i gizle
                HideInfoCanvas();
            }
        }
    }

    void ShowInfoCanvas()
    {
        infoCanvas.enabled = true;

        infoText.text = "Sphere'e T�kland�!";
    }

    void HideInfoCanvas()
    {
        infoCanvas.enabled = false;
    }
}
