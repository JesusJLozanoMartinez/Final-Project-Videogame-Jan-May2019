using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Virus : MonoBehaviour {
    public static float speed = 10;
    public Text win;
    public Text countText;
    //public int count;
    public int winCount;
    [SerializeField] private HealthBar healthBar;
    public string currentLevel;

    public Text lifeTu;
    public float life;

    public Text speedText;

    //private void Start() {
    //    rigidbody.free
    //}

    private void Start() {
        SetText();
        lifeTu.text = "Health: " + life.ToString();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        SetText();

        if(life <= 0) {
            win.text = "You lose!";
            //Destroy(gameObject);
            if(currentLevel == "Lungs") {
                StartCoroutine(loseWaiter());
            } else
            {
                StartCoroutine(winWaiter());
            }
        } else {
           
        }
        healthBar.SetSize((life / 100));
    }

    void SetText() {
        //count = GameObject.FindGameObjectsWithTag("Antibody").Length;
        speedText.text = "Speed: " + speed;
        winCount = GameObject.FindGameObjectsWithTag("Spawner").Length;
        countText.text = "Spawners remaining: " + winCount.ToString();
        win.text = "";
        if (winCount == 0) {
            win.text = "Level passed!";
            if(currentLevel == "Lungs")
            {
                StartCoroutine(winWaiter());
            } else
            {
                StartCoroutine(finalWinWaiter());
            }
        }

        lifeTu.text = "Health: " + life.ToString();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Antibody")) {
            if (life > 0) {
                if(life > 30) {
                    life -= 1.5f;
                }
                else
                {
                    life -= 1;
                }
                print(life);
                SetText();
            }
        }
    }

    IEnumerator loseWaiter() {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(2);
    }

    IEnumerator winWaiter() {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(3);
    }

    IEnumerator finalWinWaiter()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(0);
    }
}
