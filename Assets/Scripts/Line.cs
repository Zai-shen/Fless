using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject scoreTrigger;
    public GameObject enemyLine;
    private GameObject lineLeft;
    private GameObject lineMiddle;
    private GameObject lineRight;
    private List<GameObject> lineObjects = new List<GameObject>();

    private float playerWidth;

    public float lineSpeed;
    [Range(1,14)]
    public float midSpaceInPlayerSizes;
    public float totalLineWidth;

    // Start is called before the first frame update
    void Start()
    {
        playerWidth = GameObject.Find("Player").transform.localScale.x;

        //Line = left side + middle space + right side
        float midSpace = Mathf.Clamp(playerWidth * midSpaceInPlayerSizes,1,14);

        //Left side
        float widthLeft = Random.Range(0, totalLineWidth - midSpace);
        lineLeft = Instantiate(enemyLine, new Vector3((-totalLineWidth / 2) + (widthLeft / 2), transform.position.y, transform.position.z), Quaternion.identity);
        lineLeft.transform.localScale = new Vector3(widthLeft, lineLeft.transform.localScale.y, lineLeft.transform.localScale.z);
        lineObjects.Add(lineLeft);

        //Score trigger
        lineMiddle = Instantiate(scoreTrigger, new Vector3((-totalLineWidth / 2) + widthLeft + (midSpace / 2), transform.position.y - 0.25f, transform.position.z), Quaternion.identity);
        lineMiddle.transform.localScale = new Vector3(midSpace, lineMiddle.transform.localScale.y, lineMiddle.transform.localScale.z);
        lineObjects.Add(lineMiddle);

        //Right side
        float widthRight = totalLineWidth - widthLeft - midSpace;
        lineRight = Instantiate(enemyLine, new Vector3((totalLineWidth / 2) - (widthRight / 2), transform.position.y, transform.position.z), Quaternion.identity);
        lineRight.transform.localScale = new Vector3(widthRight, lineRight.transform.localScale.y, lineRight.transform.localScale.z);
        lineObjects.Add(lineRight);

        //Debug.Log("Total:" + totalLineWidth + " Left:" + widthLeft + " Middle:" + midSpace + "Right:" + widthRight);
    }

    private void OnDrawGizmos()
    {
        Color redSeeThrough = Color.red;
        redSeeThrough.a = 0.5f;
        Gizmos.color = redSeeThrough;
        Gizmos.DrawCube(transform.position,new Vector3(totalLineWidth!=0?totalLineWidth:16f,1,1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject lineTile in lineObjects)
        {
            if (lineTile == null)
            {
                //Debug.Log("Destroying Line");
                Destroy(this.gameObject);
            }
            else
            {
                lineTile.GetComponent<Rigidbody>().velocity = new Vector3(0, lineSpeed * Time.deltaTime, 0);
            }
        }

    }
}
