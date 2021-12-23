using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public CharacterUI character;

    [TextArea(3, 10)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public CharacterUI speakerLeft;
    public CharacterUI speakerRight;
    public Line[] lines;
}
