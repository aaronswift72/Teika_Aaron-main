using System.Linq.Expressions;
//using System.Numerics;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject bgPrefab;
    public float speed;
    private GameObject[] bgs;
    public float pivotPoint;
    public float scale;

    void Start()
    {
        pivotPoint = -0.32f  * 16 * scale;
        bgPrefab.transform.localScale = new Vector3(scale, scale, scale);
        
        bgs = new GameObject[3];

        for (int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint/2 * i);
            float yPos = pivotPoint - (pivotPoint/2 * i);
            Vector2 position = new Vector2(xPos, yPos);
            bgs[i] = Instantiate(bgPrefab, position, Quaternion.identity);
        }
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            float xPos = bgs[i].transform.position.x + speed;
            float yPos = bgs[i].transform.position.y + speed;
            Vector2 position = new Vector2(xPos, yPos);
            bgs[i].transform.position = position;

            if(bgs[i].transform.position.x > -pivotPoint/2)
            {
                position = new Vector2(pivotPoint, pivotPoint);
            }
            bgs[i].transform.position = position;
        }
    }
}
