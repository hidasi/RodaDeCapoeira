using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BeatScroller : MonoBehaviour
{
    public AudioSource theMusic;
    public float beatTempo;
    public bool hasStarted;
    public GameObject leftarrow;
    public GameObject uparrow;
    public GameObject downarrow;
    public GameObject rightarrow;
    public Transform instaarrowleft;
    public Transform instaarrowup;
    public Transform instaarrowdown;
    public Transform instaarrowright;
    public bool single;
    public int NoteCounter, initialCounter;
    public int released;
    private bool timer;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        NoteCounter = initialCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            //
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            NoteCounter--;
            if (NoteCounter<0 && !timer)
            {
                StartCoroutine(NoteSpawner());
                NoteCounter = initialCounter;
                timer = true;
            }
            
        }
    }

    public void start()
    {
        if (single)
        {
            hasStarted = true;
            theMusic.Play();
        }
        if (!single)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                hasStarted = true;
                theMusic.Play();
            }
        }
        
    }

    public void stop()
    {
        hasStarted = false;
    }

    IEnumerator NoteSpawner()
    {
        yield return new WaitForSeconds(0.6f);
        int randomized = Random.Range(1, 11);
        if (randomized == 1)
        {
            Instantiate(leftarrow, instaarrowleft).transform.SetParent(transform);
        }
        if (randomized == 2)
        {
            Instantiate(uparrow, instaarrowup).transform.SetParent(transform);
        }
        if (randomized == 3)
        {
            Instantiate(downarrow, instaarrowdown).transform.SetParent(transform);
        }
        if (randomized == 4)
        {
            Instantiate(rightarrow, instaarrowright).transform.SetParent(transform);
        }
        if (randomized == 5)
        {
            Instantiate(leftarrow, instaarrowleft).transform.SetParent(transform);
        }
        if (randomized == 6)
        {
            Instantiate(uparrow, instaarrowup).transform.SetParent(transform);
        }
        if (randomized == 7)
        {
            Instantiate(downarrow, instaarrowdown).transform.SetParent(transform);
        }
        if (randomized == 8)
        {
            Instantiate(rightarrow, instaarrowright).transform.SetParent(transform);
        }
        if (randomized == 9)
        {
            Instantiate(leftarrow, instaarrowleft).transform.SetParent(transform);
            Instantiate(downarrow, instaarrowdown).transform.SetParent(transform);
        }
        if (randomized == 10)
        {
            Instantiate(uparrow, instaarrowup).transform.SetParent(transform);
            Instantiate(rightarrow, instaarrowright).transform.SetParent(transform);
        }

        released++;
        timer = false;
    }
}
