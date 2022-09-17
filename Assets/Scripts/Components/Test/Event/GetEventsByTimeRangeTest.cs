using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByTimeRangeTest : MonoBehaviour
{
    Task<SuiEventEnvelope[]> Task;

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
        
        var resLines = string.Join(",\n\t", (IEnumerable<object>) Task.Result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by time range result:  " + resultText);
        Task = null;
    }
}
