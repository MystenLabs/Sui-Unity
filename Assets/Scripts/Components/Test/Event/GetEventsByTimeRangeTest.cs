using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByTimeRangeTest : MonoBehaviour
{
    Task<object[]> Task;

    [Range(5, 100)]
    public uint Count = 100;
    
    [Range(0, 100)]
    public uint StartTime = 0;
    

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetEventsByTimeRange(Count, StartTime);
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        var resLines = string.Join(",\n\t", (IEnumerable<object>) result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by time range result:  " + resultText);
        Task = null;
    }
}
