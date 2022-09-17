using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsBySenderTest : MonoBehaviour
{
    Task<SuiEventEnvelope[]> Task;

    // substitute your object id here
    public string Address = "0x08c9e31048ce86a3538272d4adaf2069ecf26c01";
    
    [Range(0, 100)]
    public uint Count = 50;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetEventsBySender(Address, Count);
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var resLines = string.Join(",\n", (IEnumerable<SuiEventEnvelope>) Task.Result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by sender result:  " + resultText);
        Task = null;
    }
}
