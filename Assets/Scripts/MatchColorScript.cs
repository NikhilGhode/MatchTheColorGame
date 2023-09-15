using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchColorScript : MonoBehaviour
{
    // Start is called before the first frame update
    int[] checkValues = {-1,-1};
    private ClickSprite[] clickedSprites = new ClickSprite[2];
    private GameObject[] clrobjects = new GameObject[2];
    private int numClicked = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this method from ClickSprite when a sprite is clicked
    public void AddClickedSprite(ClickSprite sprite)
    {
        if (numClicked < 2)
        {
            clickedSprites[numClicked] = sprite;
            checkValues[numClicked] = sprite.colorcode;
            clrobjects[numClicked] = sprite.colorobject;
            numClicked++;

            if (numClicked == 2)
            {
                // Start checking for color matches                
                CheckMatch();
            }
        }
    }

    private void CheckMatch()
    {
        if (numClicked == 2)
        {
            if (checkValues[0] == checkValues[1])
            {
                Debug.Log("Matched: " + checkValues[0]);
                Debug.Log(clickedSprites[0].name + " " + clickedSprites[1].name);
                //Destroy(clrobjects[0].gameObject);
                //Destroy(clrobjects[1].gameObject);
                Destroy(clickedSprites[0].colorobject.gameObject, 1.5f);
                Destroy(clickedSprites[1].colorobject.gameObject, 1.5f);
                Destroy(clickedSprites[0].gameObject, 1f);
                Destroy(clickedSprites[1].gameObject, 1f);
                //GameManager.instance.totalobjectsprefabs.Remove(clickedSprites[0].colorobject.gameObject);
                //GameManager.instance.totalobjectsprefabs.Remove(clickedSprites[1].colorobject.gameObject);
                GameManager.instance.totalobjectnum.Remove(checkValues[0]);
                GameManager.instance.totalobjectnum.Remove(checkValues[1]);
                GameManager.instance.totalObjects -= 2;
            }
            else
            {
                Debug.Log("Not matched: " + checkValues[0] + " and " + checkValues[1]);
            }

            // Reset the clicked sprites and values
            numClicked = 0;
            checkValues[0] = -1;
            checkValues[1] = -1;
            clickedSprites = new ClickSprite[2];
            clrobjects = new GameObject[2];
            if (GameManager.instance.totalObjects == 1 || GameManager.instance.totalObjects == 0)
            {
                StartCoroutine(OpenGameOverPanel());
            }

            if(GameManager.instance.totalObjects == 2 && GameManager.instance.totalobjectnum[0] != GameManager.instance.totalobjectnum[1])
            {
                GameManager.instance.noMatches.SetActive(true);
                StartCoroutine(OpenGameOverPanel());
            }
        }
    }

    IEnumerator OpenGameOverPanel()
    {
        yield return new WaitForSeconds(2f);
        GameManager.instance.noMatches.SetActive(false);
        GameManager.instance.GameOver.SetActive(true);
    }
}
