using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PageScript : MonoBehaviour
{

    public GameObject Content;
    public GameObject[] SecondMenu;
    public GameObject[] SecondMenuButtons;
    public GameObject Transition;

    public int pagenum;
    public int maxpage;

    public AudioClip Swoop;
    public AudioClip BubblePop;

    private int frames = 10;
    private Vector2 fingerStart;
    private Vector2 fingerEnd;
    private bool isCoroutineExecuting = false;
    private bool bounce = false;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(OpeningTransition());
    }
    //IEnumerator OpeningTransition()
    //{
    //    Transition.SetActive(true);
    //    Transition.GetComponent<Image>().CrossFadeAlpha(0, 1f, false);
    //    yield return new WaitForSeconds(2f);
    //    Transition.SetActive(false);
    //}
    // Update is called once per frame
    void Update()
    {
        if (!bounce)
        {
            //Swipe input
            if (Input.GetMouseButtonDown(0))
            {
                //fingerStart = touch.position;
                //fingerEnd = touch.position;
                fingerStart = Input.mousePosition;
                fingerEnd = Input.mousePosition;
            }
            //if (touch.phase == TouchPhase.Moved)
            if (Input.GetMouseButton(0))
            {
                //fingerEnd = touch.position;
                fingerEnd = Input.mousePosition;

                //Swipe Direction
                if ((fingerStart.x - fingerEnd.x) > 50)
                { pageRight(); }
                else if ((fingerStart.x - fingerEnd.x) < -50)
                { pageLeft(); }

                //After the checks are performed, set the fingerStart & fingerEnd to be the same
            }
            //if (touch.phase == TouchPhase.Ended)
            if (Input.GetMouseButtonUp(0))
            {
                fingerStart = Vector2.zero;
                fingerEnd = Vector2.zero;
            }
        }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (bounce)
                { StartCoroutine(BounceDown(pagenum - 1)); }
            }
    }

    public void pageLeft()
    {
        if (pagenum > 1)
        {
            StartCoroutine(MovePanels(1));
        }
    }
    public void pageRight()
    {
        if (pagenum < maxpage)
        {
            StartCoroutine(MovePanels(-1));
        }
    }


    IEnumerator MovePanels(int dir)
    {
        if (isCoroutineExecuting) { yield break; }

        gameObject.GetComponent<AudioSource>().PlayOneShot(Swoop);

        isCoroutineExecuting = true;
        pagenum -= dir;
        for (int i = 0; i < frames; i++)
        {
            // Move panels according to direction
            Content.transform.localPosition += new Vector3(dir * 700 / frames, 0, 0);
            yield return new WaitForEndOfFrame();
        }

        isCoroutineExecuting = false;
    }

    public void pageButtonPress(int page)
    {
        if(bounce)
        {
            if(page > pagenum)
            { StartCoroutine(BounceSequence(-1, page-1)); }
            else if (page<pagenum)
            { StartCoroutine(BounceSequence(1, page-1)); }
            else //pagenum == page
            { StartCoroutine(BounceDown(page - 1)); }
        }
        else
        {
            if (page > pagenum)
            { pageRight(); }
            else if (page < pagenum)
            { pageLeft(); }
            else //pagenum == page
            { StartCoroutine(BounceUp(page - 1)); }
        }
    }
    IEnumerator BounceUp(int page)
    {
        if (isCoroutineExecuting) { yield break; }

        isCoroutineExecuting = true;


        for (int i = 0; i < 3; i++)
        {
            // Move panels according to direction
            Content.transform.localPosition += new Vector3(0, -50 / 3, 0);
            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < 15; i++)
        {
            // Move panels according to direction
            Content.transform.localPosition += new Vector3(0, 900 / 15, 0);
            yield return new WaitForEndOfFrame();
        }


        SecondMenu[page].SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            SecondMenu[page].transform.localPosition += new Vector3(0, -900 / 10, 0);
            SecondMenu[page].transform.localScale += new Vector3(0.9f / 10f, 0.9f / 10f, 0);
            SecondMenuButtons[page * 2].transform.localPosition += new Vector3( -300 / 10,0,0);
            SecondMenuButtons[page * 2 + 1].transform.localPosition += new Vector3(300 / 10, 0, 0);
            if (i == 7) { gameObject.GetComponent<AudioSource>().PlayOneShot(BubblePop); }

            yield return new WaitForEndOfFrame();
        }
        gameObject.GetComponent<AudioSource>().PlayOneShot(BubblePop);


        bounce = true;

        isCoroutineExecuting = false;
    }
    IEnumerator BounceDown(int page)
    {
        if (isCoroutineExecuting) { yield break; }

        isCoroutineExecuting = true;

        gameObject.GetComponent<AudioSource>().PlayOneShot(BubblePop);

        for (int i = 0; i < 10; i++)
        {
            SecondMenu[page].transform.localPosition += new Vector3(0, 900 / 10, 0);
            SecondMenu[page].transform.localScale += new Vector3(-0.9f / 10f, -0.9f / 10f, 0);
            SecondMenuButtons[page * 2].transform.localPosition += new Vector3(300 / 10, 0, 0);
            SecondMenuButtons[page * 2 + 1].transform.localPosition += new Vector3(-300 / 10, 0, 0);

            if (i == 4)
            { gameObject.GetComponent<AudioSource>().PlayOneShot(BubblePop); }
            yield return new WaitForEndOfFrame();
        }


        SecondMenu[page].SetActive(false);

        for (int i = 15; i > 0; i--)
        {
            // Move panels according to direction
            Content.transform.localPosition += new Vector3(0, -900 / 15, 0);
            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < 3; i++)
        {
            // Move panels according to direction
            Content.transform.localPosition += new Vector3(0, 50 / 3, 0);
            yield return new WaitForEndOfFrame();
        }


        bounce = false;

        isCoroutineExecuting = false;
    }
    IEnumerator BounceSequence(int dir, int page)
    {
        yield return StartCoroutine(BounceDown(pagenum-1));
        yield return StartCoroutine(MovePanels(dir));
        yield return StartCoroutine(BounceUp(page));
    }

    public void SingleJumper()
    {
        Application.LoadLevel(1);
    }
    public void SingleBrick()
    {
        Application.LoadLevel(2);
    }

    public void MLBrick()
    {
        //SceneManager.LoadScene("LM Brickbreaker Master Scene");
        Application.LoadLevel(3);
        //StartCoroutine(MLBrickEnum());
    }
    public void MLPong()
    {
        //SceneManager.LoadScene("LM Brickbreaker Master Scene");
        Application.LoadLevel(4);
        //StartCoroutine(MLBrickEnum());
    }
    //IEnumerator MLBrickEnum()
    //{
    //    //Transition.SetActive(true);
    //    //Transition.GetComponent<Image>().CrossFadeAlpha(0, 0f, true);
    //    //Transition.GetComponent<Image>().CrossFadeAlpha(1, 1f, true);
    //    //yield return new WaitForSeconds(1f);
    //    SceneManager.LoadScene("LM Brickbreaker Master Scene");
    //}
}




