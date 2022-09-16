using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByObjectTest : MonoBehaviour
{
    Task<object[]> Task;

    // substitute your object id here
    public string ObjectID = "0x30946e8bc320488ddac2a92881345131d3bb1da3";
    
    [Range(0, 100)]
    public uint Count = 50;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetEventsByObject(ObjectID, Count, 0, 9007199254740991);
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        var resLines = string.Join(",\n\t", (IEnumerable<object>) result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by object result:  " + resultText);
        Task = null;
    }
}
