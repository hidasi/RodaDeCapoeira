using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;
    public int currentScore;
    public int scorePerNote;
    public Text scoreText;
    //public Text multiText;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    private float startVolume;
    private float fadeTime;
    public int hits;

    public GameObject final;
    
    
    public player1animSingle PERSONAGEM1;
    public List<int> scoresforanim = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        PERSONAGEM1 = FindObjectOfType<player1animSingle>();
        instance = this;
        scoreText.text = "Score: 0";
        startVolume = theMusic.volume;
        currentMultiplier = 1;
        start();
        fadeTime = 1.5f;
        StartCoroutine(MusicControl());
        //var scoresforanim = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startPlaying)
        {
            
        }
        
    }

    public void start()
    {
        startPlaying = true;
        theBS.start();
    }
    public void NoteHit()
    {
        

        //multiText.text = "Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        hits++;
        if (theBS.released > 10)
        {
            
            if (hits >= 9)
            {
                scoresforanim.Add(3);
                currentMultiplier = 3;
                PERSONAGEM1.great();
            } else
            if (hits >= 4 && hits<=8)
            {
                scoresforanim.Add(2);
                currentMultiplier = 2;
                PERSONAGEM1.good();
            }
            else if (hits <= 3)
            {
                scoresforanim.Add(1);
                PERSONAGEM1.fail();
            }
            hits = 0;
            theBS.released = 0;
            currentMultiplier = 1;


        }
    }
    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;
        //multiText.text = "Multiplier: x" + currentMultiplier;
    }

    IEnumerator MusicControl()
    {
        yield return new WaitForSeconds(120f);
        while (theMusic.volume > 0)
        {
            theMusic.volume -= startVolume * Time.deltaTime / fadeTime;
        }
        theBS.stop();
        final.SetActive(true);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
