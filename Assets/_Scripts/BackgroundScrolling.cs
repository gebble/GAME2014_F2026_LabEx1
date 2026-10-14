using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField]
    private Vector2 scrollSpeed = new Vector2(0f, 0.5f);

    private RawImage rawImage;
    private Vector2 uvOffset;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        uvOffset += scrollSpeed * Time.deltaTime;
        rawImage.uvRect = new Rect(uvOffset, rawImage.uvRect.size);
    }
}