using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Up : MonoBehaviour
{
    //
    private GameSession gameSession;
    public GameObject tt;
    public int dd;
    public int dd2;
    public int dd3;
    public Slider slider;
    public Slider slider2;
    public Slider slider3;
    public bool truee = true;
    [SerializeField] AudioClip oofsound;
    [SerializeField] AudioClip oofssound;


    //

    // Start is called before the first frame update
    void Start()
    {
        gameSession = GetComponent<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T) && truee)
        {
            Time.timeScale = 0;
            tt.SetActive(true);
            truee = false;
        }
        else if (Input.GetKeyDown(KeyCode.T) && !truee)
        {
            Time.timeScale = 1;
            tt.SetActive(false);
            truee = true;
        }
        slider.value = dd;
        slider2.value = dd2;
        slider3.value = dd3;
    }
    public void Up1()
    {
        if (dd < 11)
        {
            dd += 1;
            AudioSource.PlayClipAtPoint(oofsound, Camera.main.transform.position);

        }
        else if (dd == 10)
        {
            AudioSource.PlayClipAtPoint(oofssound, Camera.main.transform.position);

        }
    }
    public void Up2()
    {
        if (dd2 < 11)
        {
            dd2 += 1;
            AudioSource.PlayClipAtPoint(oofsound, Camera.main.transform.position);

        }
        else if (dd2 == 10)
        {
            AudioSource.PlayClipAtPoint(oofssound, Camera.main.transform.position);

        }
    }
    public void Up3()
    {
        if (dd3 < 11)
        {
            dd3 += 1;
            AudioSource.PlayClipAtPoint(oofsound, Camera.main.transform.position);

        }
        else if (dd3 == 10)
        {
            AudioSource.PlayClipAtPoint(oofssound, Camera.main.transform.position);

        }
    }
}
