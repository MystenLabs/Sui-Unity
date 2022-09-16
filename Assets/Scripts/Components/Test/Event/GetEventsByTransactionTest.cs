using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByTransactionTest : MonoBehaviour
{
    Task<object[]> Task;

    // substitute your transaction digest here
    public string Digest = "XbyTWT8UZ1qXEM4/sdRLOzF+uwtHEEjuoj8m0VKVZFQ=";
    
    [Range(0, 100)]
    public uint Count = 50;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetEventsByTransaction(Digest, Count);
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        var resLines = string.Join(",\n\t", (IEnumerable<object>) result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by transaction result:  " + resultText);
        Task = null;
    }
}
