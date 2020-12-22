using UnityEngine;

public class InputNotifier : MonoBehaviour
{
    public FloatEvent OnInputReceived;
    private void Update()
    {
        float horizontalnput = Input.GetAxisRaw("Horizontal");
        OnInputReceived?.Invoke(horizontalnput);
    }
}
