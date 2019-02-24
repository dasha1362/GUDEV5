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
        SceneManager.LoadScene(1);
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

    private void runScene()
    {
        speech1.SetActive(true);
        speech1.GetComponentInChildren<TextMeshPro>().text = "It's a beautiful day!";
        DateTime ts = DateTime.Now.AddSeconds(2);
        do { } while (DateTime.Now < ts);
        speech1.GetComponentInChildren<TextMeshPro>().text = "Let's make " + p1Fruit.ToString() + " jam!";
        ts = DateTime.Now.AddSeconds(3);
        do { } while (DateTime.Now < ts);
        speech1.SetActive(false);
        speech2.SetActive(true);
        speech2.GetComponentInChildren<TextMeshPro>().text = "But I want to make " + p2Fruit.ToString() + " jam!";
        ts = DateTime.Now.AddSeconds(3);
        do { } while (DateTime.Now < ts);
        speech2.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        angry1.SetActive(true);
        angry2.SetActive(true);
        ts = DateTime.Now.AddSeconds(1);
        do { } while (DateTime.Now < ts);
        angry1.transform.localScale += new Vector3(1, 1, 0);
        angry2.transform.localScale += new Vector3(1, 1, 0);
        ts = DateTime.Now.AddSeconds(1);
        do { } while (DateTime.Now < ts);
        angry1.transform.localScale += new Vector3(1, 1, 0);
        angry2.transform.localScale += new Vector3(1, 1, 0);
        ts = DateTime.Now.AddSeconds(1);
        do { } while (DateTime.Now < ts);
        angry1.transform.localScale += new Vector3(1, 1, 0);
        angry2.transform.localScale += new Vector3(1, 1, 0);
        ts = DateTime.Now.AddSeconds(1);
        do { } while (DateTime.Now < ts);
    }

}