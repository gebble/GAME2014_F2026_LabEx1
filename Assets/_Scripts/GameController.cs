using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreLabel;

    [SerializeField]
    private TMP_Text livesLabel;

    [SerializeField]
    private TMP_Text sceneLabel;

    // Update is called once per frame
    void Update()
    {
        MoveLabelsToSafeArea();
        CheckOrientation();
    }

    private void MoveLabelsToSafeArea()
    {
        float scoreLabelHalfWidth = scoreLabel.rectTransform.rect.width * 0.5f;
        float scoreLabelHalfHeight = scoreLabel.rectTransform.rect.height * 0.5f;

        float livesLabelHalfWidth = livesLabel.rectTransform.rect.width * 0.5f;
        float livesLabelHalfHeight = livesLabel.rectTransform.rect.height * 0.5f;

        // Place Score Label in the Top-Left of the Safe Area
        scoreLabel.rectTransform.position = new Vector2(
            Screen.safeArea.xMin + scoreLabelHalfWidth,
            Screen.safeArea.yMax - scoreLabelHalfHeight
        );

        // Place Lives Label in the Top-Right of the Safe Area
        livesLabel.rectTransform.position = new Vector2(
            Screen.safeArea.xMax - livesLabelHalfWidth,
            Screen.safeArea.yMax - livesLabelHalfHeight
        );
    }

    private void CheckOrientation()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                sceneLabel.text = "Portrait";
                break;
            case ScreenOrientation.LandscapeLeft:
                sceneLabel.text = "Landscape Left";
                break;
            case ScreenOrientation.LandscapeRight:
                sceneLabel.text = "Landscape Right";
                break;
            case ScreenOrientation.PortraitUpsideDown:
                sceneLabel.text = "Portrait Upside Down";
                break;
            default:
                sceneLabel.text = "Unknown";
                break;
        }
    }
}