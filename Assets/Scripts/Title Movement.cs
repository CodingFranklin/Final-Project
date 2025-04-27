using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMovement : MonoBehaviour
{
    RectTransform rt;

    [SerializeField] float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rt.anchoredPosition += Vector2.right * moveSpeed * Time.deltaTime;

        if (rt.anchoredPosition.x >= 1610)
        {
            rt.anchoredPosition = new Vector2(-1610, rt.anchoredPosition.y);
        }
    }
}
