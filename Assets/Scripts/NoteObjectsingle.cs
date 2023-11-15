using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectsingle : MonoBehaviour
{
    public bool canBePressed;
    public int key;
    public ButtonControllerleft BCleft;
    public ButtonControllerup BCup;
    public ButtonControllerdown BCdown;
    public ButtonControllerright BCright;

    public ParticleSystem part;
    
    // Start is called before the first frame update
    void Start()
    {
        BCleft = FindObjectOfType<ButtonControllerleft>();
        BCup = FindObjectOfType<ButtonControllerup>();
        BCdown = FindObjectOfType<ButtonControllerdown>();
        BCright = FindObjectOfType<ButtonControllerright>();
    }

    // Update is called once per frame
    void Update()
    {
        if (key == 4 && BCleft.left)
        {
            if (canBePressed)
            {
                Instantiate(part, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
        if (key == 2 && BCup.up)
        {
            if (canBePressed)
            {
                Instantiate(part, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
        if (key == 3 && BCdown.down)
        {
            if (canBePressed)
            {
                Instantiate(part, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
        if (key == 1 && BCright.right)
        {
            if (canBePressed)
            {
                Instantiate(part, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
        }
    }
}
