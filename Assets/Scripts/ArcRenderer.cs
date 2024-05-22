using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcRenderer : MonoBehaviour
{
    public GameObject arrowPrefab; // the arrow head
    public GameObject dotPrefab; // the dots
    public int poolSize = 50; // the size of our dot pool
    private List<GameObject> dotPool = new List<GameObject>(); // the dot pool
    private GameObject arrowInstance; // holds a reference to the arrow head

    public float spacing = 40; // the spacing of the dots
    public float arrowAngleAdjustment = 180; // Angle correction for the Arrowhead.
    public int dotsToSkip = 2; // Number of dots to skip to give the Arrowhead space.
    private Vector3 arrowDirection; // Holds the position the ArrowHead needs to point from.


    void OnDisable()
    {
        arrowInstance.transform.localPosition = Vector3.zero;
        for (int i = 0; i < dotPool.Count; i++)
        {
            dotPool[i].transform.position = Vector3.zero;
        }
    }

    void Start()
    {
        arrowInstance = Instantiate(arrowPrefab, transform);
        arrowInstance.transform.localPosition = Vector3.zero; // is the same as new Vector3(0,0,0). This also works for Vector2
        InitializeDotPool(poolSize);
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 startPos = transform.position;
        Vector3 midPoint = CalculatedMidPoint(startPos, mousePos);

        UpdateArc(startPos, midPoint, mousePos);
        PositionAndRotateArrow(mousePos);
    }

    void UpdateArc(Vector3 start, Vector3 mid, Vector3 end)
    {
        int numDots = Mathf.CeilToInt(Vector3.Distance(start, end) / spacing);


        for (int i = 0; i < numDots && i < dotPool.Count; i++)
        {
            float t = i / (float)numDots;
            t = Mathf.Clamp(t, 0f, 1f); // ensure t stays within the range [0,1]

            Vector3 position = QuadraticBezierPoint(start, mid, end, t);

            if (i != numDots - dotsToSkip) // acho que é para pular dots para ter espaço para arrow head
            {
                dotPool[i].transform.position = position;
                dotPool[i].SetActive(true);
            }

            if (i == numDots - (dotsToSkip + 1) && i - dotsToSkip + 1 >= 0)
            {
                arrowDirection = dotPool[i].transform.position; // acho que pega o último dot válido como referência para direção da arrow
            }

        }

        // Deactivate unused dots
        for (int i = numDots - dotsToSkip; i < dotPool.Count; i++)
        {
            if (i > 0)
            {
                dotPool[i].SetActive(false);
            }
        }
    }


    void PositionAndRotateArrow(Vector3 position)
    {
        arrowInstance.transform.position = position;
        Vector3 direction = arrowDirection - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += arrowAngleAdjustment;
        arrowInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Vector3.foward the same as (0,0,1)
    }

    Vector3 CalculatedMidPoint(Vector3 start, Vector3 end)
    {
        Vector3 midpoint = (start + end) / 2;
        float arcHeight = Vector3.Distance(start, end) / 3f;
        midpoint.y += arcHeight;
        return midpoint;
    }

    Vector3 QuadraticBezierPoint(Vector3 start, Vector3 control, Vector3 end, float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 point = uu * start;
        point += 2 * u * t * control;
        point += tt * end;
        return point;
    }
    void InitializeDotPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject dot = Instantiate(dotPrefab, Vector3.zero, Quaternion.identity, transform);
            dot.SetActive(false);
            dotPool.Add(dot);
        }
    }


}
