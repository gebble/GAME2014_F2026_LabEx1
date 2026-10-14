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

    private ScreenOrientation lastOrientation;

    void Start()
    {
        // Run once at startup
        lastOrientation = Screen.orientation;
        MoveLabelsToSafeArea();
        CheckOrientation();
    }

    void Update()
    {
        // ONLY recalculate UI when the screen orientation actually changes!
        if (Screen.orientation != lastOrientation)
        {
            lastOrientation = Screen.orientation;
            MoveLabelsToSafeArea();
            CheckOrientation();
        }
    }

    private void MoveLabelsToSafeArea()
    {
        float scoreLabelHalfWidth = scoreLabel.rectTransform.rect.width * 0.5f;
        float scoreLabelHalfHeight = scoreLabel.rectTransform.rect.height * 0.5f;

        float livesLabelHalfWidth = livesLabel.rectTransform.rect.width * 0.5f;
        float livesLabelHalfHeight = livesLabel.rectTransform.rect.height * 0.5f;

        scoreLabel.rectTransform.position = new Vector2(
            Screen.safeArea.xMin + scoreLabelHalfWidth,
            Screen.safeArea.yMax - scoreLabelHalfHeight
        );

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