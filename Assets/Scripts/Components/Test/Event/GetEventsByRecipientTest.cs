using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByRecipientTest : MonoBehaviour
{
    Task<object[]> Task;

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
        
        var result = Task.Result;
        var resLines = string.Join(",\n", (IEnumerable<object>) result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by recipient result:  " + resultText);
        Task = null;
    }
}
