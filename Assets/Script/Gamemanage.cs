using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Gamemanage : MonoBehaviour
{

    public GameObject GameOverpanel;
    public GameObject GameClearpanel;
    public TextMeshProUGUI Leveltext;
    public TextMeshProUGUI Leveltext2;
    public TextMeshProUGUI Hptext;
    public GameObject death;

    public int gameLevel = 1;
    public int hp = 50;

    
    // Start is called before the first frame update
    void Start()
    {
        hp = 50;
        GameOverpanel.SetActive(false);
        GameClearpanel.SetActive(false); 
        if (PlayerPrefs.HasKey("level"))
        {
            gameLevel = PlayerPrefs.GetInt("level");
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        if (hp<=0)
        {
            GameOver();
        }
        Hptext.text = "HP : " + hp.ToString();
        Leveltext2.text = "Level." + gameLevel.ToString();


    }
    public void GoMain()
    {
        gameLevel = 1;
        PlayerPrefs.SetInt("level", gameLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
        
    }

    public void GameOver()
    {
        GameOverpanel.SetActive(true);
        gameLevel = 1;
        PlayerPrefs.SetInt("level", gameLevel);
        PlayerPrefs.Save();

    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");

    }
    public void GameClear()
    {
        
        GameClearpanel.SetActive(true);
        Leveltext.text = "Level." + gameLevel.ToString();
        death.SetActive(false);
        
    }

    public void NextLevel()
    {
        gameLevel++;
        PlayerPrefs.SetInt("level", gameLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.position = new Vector3(collision.transform.position.x -5,0,0);
            OnDamage();
        
        }
    }

    public void OnDamage()
    {
        hp -= gameLevel*2;
    }
}
