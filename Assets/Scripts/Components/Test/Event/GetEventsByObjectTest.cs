using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByObjectTest : MonoBehaviour
{
    Task<object[]> Task;

    // substitute your object id here
    public string ObjectID = "0x0754d12ea8d4698cb861d11cb192574b53c19925";
    
    [Range(0, 100)]
    public uint Count = 50;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetEventsByObject(ObjectID, Count);
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
