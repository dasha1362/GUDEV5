using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    private Ingredient p1Fruit;
    private Ingredient p2Fruit;

    public GameObject speech1;
    public GameObject speech2;

    public GameObject player1;
    public GameObject player2;
    public GameObject angry1;
    public GameObject angry2;

    // Start is called before the first frame update
    void Start()
    {
        p1Fruit = (Ingredient)UnityEngine.Random.Range(0, 3);
        p2Fruit = (Ingredient)UnityEngine.Random.Range(0, 3);
        while (p2Fruit == p1Fruit)
        {
            p2Fruit = (Ingredient)UnityEngine.Random.Range(0, 3);
        }
        PersistingData.Jam1 = p1Fruit;
        PersistingData.Jam2 = p2Fruit;
        loadFruit();
        runScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void loadFruit()
    {
        GameObject instance1 = Instantiate(Resources.Load(p1Fruit.ToString(), typeof(GameObject)),
            new Vector3((float)4.215132, (float)1.603847, (float)(-4.2)), Quaternion.identity) as GameObject;
        GameObject instance2 = Instantiate(Resources.Load(p1Fruit.ToString(), typeof(GameObject)),
            new Vector3((float)4.868, (float)1.603847, (float)(-3.716)), Quaternion.identity) as GameObject;
        GameObject instance3 = Instantiate(Resources.Load(p2Fruit.ToString(), typeof(GameObject)),
            new Vector3((float)8.887, (float)1.464, (float)(-2.592)), Quaternion.identity) as GameObject;
        GameObject instance4 = Instantiate(Resources.Load(p2Fruit.ToString(), typeof(GameObject)),
            new Vector3((float)9.465, (float)1.738, (float)(-2.832)), Quaternion.identity) as GameObject;
        GameObject instance5 = Instantiate(Resources.Load(p2Fruit.ToString(), typeof(GameObject)),
            new Vector3((float)9.962, (float)1.544, (float)(-3.207)), Quaternion.identity) as GameObject;
    }

    void doSpeech1()
    {
        speech1.SetActive(true);
        speech1.GetComponentInChildren<TextMeshProUGUI>().text = "It's a beautiful day!";
    }

    void doSpeech2()
    {
        speech1.GetComponentInChildren<TextMeshProUGUI>().text = "Let's make\n " + p1Fruit.ToString() + " jam!";
    }

    void doSpeech3()
    {
        speech1.SetActive(false);
        speech2.SetActive(true);
        speech2.GetComponentInChildren<TextMeshProUGUI>().text = "But I want\nto make\n" + p2Fruit.ToString() + " jam!";
    }

    void switchSprites()
    {
        speech2.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        angry1.SetActive(true);
        angry2.SetActive(true);
    }

    void increaseSize()
    {
        angry1.transform.localScale += new Vector3(1, 1, 0);
        angry2.transform.localScale += new Vector3(1, 1, 0);
    }

    void loadMainGame()
    {
        SceneManager.LoadScene(1);
    }

    private void runScene()
    {
        doSpeech1();
        Invoke(nameof(doSpeech2), 2);
        Invoke(nameof(doSpeech3), 5);
        Invoke(nameof(switchSprites), 7);
        Invoke(nameof(increaseSize), 8);
        Invoke(nameof(increaseSize), 9);
        Invoke(nameof(increaseSize), 10);
        Invoke(nameof(loadMainGame), 11);
    }

}