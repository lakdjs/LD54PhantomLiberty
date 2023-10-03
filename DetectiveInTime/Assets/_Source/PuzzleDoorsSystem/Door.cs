using UnityEngine;

namespace PuzzleDoorsSystem
{
    public class Door : MonoBehaviour
    {
        [field: SerializeField] public int IndexOfTheDoor { get; private set; }
        [field: SerializeField] public KeyCode CodeToOpen { get; private set; }
    }
}
