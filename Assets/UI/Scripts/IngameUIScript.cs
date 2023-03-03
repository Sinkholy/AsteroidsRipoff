using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.Entities;

using UnityEngine;
using UnityEngine.UIElements;

public class IngameUIScript : MonoBehaviour
{
    UIDocument uiDoc;
    [SerializeField]
    Player player;

    Label velocityLabel;
    Label coordinatesLabel;
    Label directionLabel;

    // Start is called before the first frame update
    void Start()
    {
        uiDoc = GetComponent<UIDocument>();

        var root = uiDoc.rootVisualElement;

        var labels = uiDoc.rootVisualElement.Q<Label>();

        velocityLabel = uiDoc.rootVisualElement.Q<Label>("Velocity");
        coordinatesLabel = uiDoc.rootVisualElement.Q<Label>("Coordinates");
        directionLabel = uiDoc.rootVisualElement.Q<Label>("Rotation");
    }

    // Update is called once per frame
    void Update()
    {
        velocityLabel.text = player.Velocity.ToString();
		directionLabel.text = player.RotationAngle.ToString();
		coordinatesLabel.text = player.WorldCoordinates.ToString();
        
    }
}
