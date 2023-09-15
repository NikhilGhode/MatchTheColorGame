using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSprite : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isClicked = false;    
    private Vector2 initialScale = new Vector2(0.5f, 0.5f);

    public int colorcode;
    public GameObject colorobject;
    private MatchColorScript matchColorScript;

    //Lerp variables
    float timeElapsed = 0;
    float timeElapsed2 = 0;
    float lerpDuration = 0.3f;
    float startValue = 0.5f;
    float endValue = 0;
    float valueToLerp;

    void Start()
    {
        matchColorScript = FindObjectOfType<MatchColorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {

            if (timeElapsed < lerpDuration)
            {
                timeElapsed += Time.deltaTime;                
                valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                transform.localScale = new Vector2(valueToLerp, transform.localScale.y);
            }
            else
            {
                StartCoroutine(scaleBack());
            }            
        }


        
        if (Input.GetMouseButtonDown(0))
        {            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit.collider != null)
            {                
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Clicked");
                    timeElapsed2 = 0;
                    timeElapsed = 0;
                    Debug.Log("Value = " + colorcode);
                    if (matchColorScript != null)
                    {
                        matchColorScript.AddClickedSprite(this);
                    }
                    isClicked = true;
                }
            }
        }
    }    

    IEnumerator scaleBack()
    {
        yield return new WaitForSeconds(0.3f);
        if (timeElapsed2 < lerpDuration)
        {
            timeElapsed2 += Time.deltaTime;
            valueToLerp = Mathf.Lerp(endValue, startValue, timeElapsed2 / lerpDuration);
            transform.localScale = new Vector2(valueToLerp, transform.localScale.y);
        }
        else
        {
            isClicked = false;
            transform.localScale = initialScale;            
        }
    }


}
