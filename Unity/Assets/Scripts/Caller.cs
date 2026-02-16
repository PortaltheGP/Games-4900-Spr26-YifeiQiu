using UnityEngine;

public class Caller : MonoBehaviour
{
    public GameObject receiver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoCall();
    }
    private void DoCall()
    {
        Debug.Log("Hello Friend");
        receiver.GetComponent<Receiver>().OnCalled();
    }
}
