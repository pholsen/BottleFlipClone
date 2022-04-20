using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottle : MonoBehaviour
{
    public int x;
    public int y;

    public int HowMuchJump = 0;
    public bool canJump = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& canJump == true)
        {
            HowMuchJump++;

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x,y,0);
            gameObject.GetComponent<Animator>().SetTrigger("Flip");

        }
        if (HowMuchJump >=2)
        {
            canJump = false;
        }
    }

    public void Gravity()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x, -y, 0);
    }
    public void Stop()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            HowMuchJump = 0;
            canJump = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y);
        }
        if (collision.gameObject.tag == "Fin")
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
        }
    }

    
}
