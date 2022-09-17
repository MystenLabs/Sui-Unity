using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByModuleTest : MonoBehaviour
{
    Task<SuiEventEnvelope[]> Task;

    // substitute your struct name here
    public string Package = "0x2";
    public string Module = "devnet_nft";
    
    [Range(0, 100)]
    public uint Count = 50;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetEventsByModule(Package, Module, Count);
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        var resLines = string.Join(",\n", (IEnumerable<SuiEventEnvelope>) result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by module result:  " + resultText);
        Task = null;
    }
}
