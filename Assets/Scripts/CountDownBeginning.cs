using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownBeginning : MonoBehaviour
{
    [SerializeField]
    private GameObject onePage;
    [SerializeField]
    private GameObject twoPage;
    [SerializeField]
    private GameObject threePage;
    [SerializeField]
    private GameObject goPage;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameManager ballThrowControle;

    void Start()
    {
        SetPageState(PageState.None);
        gameManager = FindObjectOfType<GameManager>();
        
    }
    
    enum PageState
        // the five countdown page states
    {
        None,
        Three,
        Two,
        One,
        Go
        
    }
    
    
    // showing countdown with subsequent start of pages needed for actual game
    public void ShowCountdown()
    {
        //deactivateShooting();
        StartCoroutine(CountingDown());
        
    }
    
    // coroutine for showing the countdown and subsequent start of pages needed for actual game
    IEnumerator CountingDown()
    {
       
        yield return new WaitForSeconds(1);
        SetPageState(PageState.Three);
        
        yield return new WaitForSeconds(1);
        SetPageState(PageState.Two);
        
        yield return new WaitForSeconds(1);
        SetPageState(PageState.One);
        
        yield return new WaitForSeconds(1);
        SetPageState(PageState.Go);
        yield return new WaitForSeconds(1);
        goPage.SetActive(false);
        gameManager.StartTimer();
        gameManager.OnGameStart();
        
        
        
    }
    
    void SetPageState(PageState state)
        // activate needed page and deactivate all others
    {
        switch (state)
        {
            case PageState.None:
                threePage.SetActive(false);
                twoPage.SetActive(false);
                onePage.SetActive(false);
                goPage.SetActive(false);
                break;
            case PageState.Three:
                threePage.SetActive(true);
                twoPage.SetActive(false);
                onePage.SetActive(false);
                goPage.SetActive(false);
                break;
            case PageState.Two:
                threePage.SetActive(false);
                twoPage.SetActive(true);
                onePage.SetActive(false);
                goPage.SetActive(false);
                break;
            case PageState.One:
                threePage.SetActive(false);
                twoPage.SetActive(false);
                onePage.SetActive(true);
                goPage.SetActive(false);
                break;
            case PageState.Go:
                threePage.SetActive(false);
                twoPage.SetActive(false);
                onePage.SetActive(false);
                goPage.SetActive(true);
                break;
            
           
        }
    }
}
