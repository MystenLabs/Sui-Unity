using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByTransactionTest : MonoBehaviour
{
    Task<SuiEventEnvelope[]> Task;

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
        if (Task is not { IsCompleted: true }) 
            return;
        
        var resLines = string.Join(",\n", (IEnumerable<SuiEventEnvelope>) Task.Result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by transaction result:  " + resultText);
        Task = null;
    }
}
