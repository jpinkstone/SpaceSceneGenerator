using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerScript : MonoBehaviour
{
    public GameObject VFXTemplate;
    public Camera cam;
    public Text galaxiesOnResetText;
    public Slider galaxySlider;
    public GameObject canvas;

    private Coroutine co_HideCursor;
    private int galaxyCount = 3;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        canvas.SetActive(false);
        CreateGalaxies(galaxyCount);
        

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        galaxyCount =  (int) galaxySlider.value;
        galaxiesOnResetText.text = "Galaxies On Reset: " + galaxyCount.ToString();

        // Hide or unhide mouse
        if (Input.GetAxis("Mouse X") == 0 && (Input.GetAxis("Mouse Y") == 0))
        {
            if (co_HideCursor == null)
            {
                co_HideCursor = StartCoroutine(HideCursor());
            }
        }
        else
        {
            if (co_HideCursor != null)
            {
                StopCoroutine(co_HideCursor);
                co_HideCursor = null;
                Cursor.visible = true;
                canvas.SetActive(true);
            }
        }
    }


    private IEnumerator HideCursor()
    {
        yield return new WaitForSeconds(3);
        Cursor.visible = false;
        canvas.SetActive(false);
    }


    public void AdjustFOV(float fov)
    {
        cam.fieldOfView = fov;
    }

    public void CreateGalaxies(int number)
    {
        //destroy current galaxies
        var galaxies = GameObject.FindGameObjectsWithTag("galaxy");
        foreach (var galaxy in galaxies)
        {
            Destroy(galaxy);
        }

        //create specified number of galaxies
        for (int x = 0; x < number; x++)
        {
            Instantiate(VFXTemplate, transform.position, transform.rotation);
        }
    }

   

    public void ResetGalaxies()
    {
        CreateGalaxies(galaxyCount);
    }


}
