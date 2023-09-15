using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    
    public TMP_InputField row;    
    public TMP_InputField column;
    public GameObject gridplate;
    public GameObject background;
    public GameObject[] colors;
    public Transform parentobject;
    public int totalObjects = -1;
    public GameObject GameOver;
    public GameObject noMatches;

    public List<GameObject> totalobjectsprefab = new List<GameObject>();
    public List<int> totalobjectnum = new List<int>();
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
