using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //€блока, €ке кидаЇ €блун€
    public GameObject applePrefab;
    //Ўвидк≥сть перем≥щенн€
    public float speed = 1f;
    //л≥ва ≥ права мережа перем≥щенн€
    public float leftAndRightEdge = 10f;
    //≤мов≥рн≥сть зм≥ни напр€мку руху
    public float chanceToChangeDirections = 0.1f;
    //як≥льк≥сть €блук у секунду
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2);
    }
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = this.transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if(pos.x<-leftAndRightEdge)
        {
            speed=Mathf.Abs(speed);
        }
        else if(pos.x>leftAndRightEdge)
        {
            speed=-Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if(Random.value < chanceToChangeDirections)
        {
            speed*=-1;
        }
    }
}
