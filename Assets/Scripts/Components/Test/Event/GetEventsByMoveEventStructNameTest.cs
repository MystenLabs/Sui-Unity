using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetEventsByMoveEventStructNameTest : MonoBehaviour
{
    Task<SuiEventEnvelope[]> Task;

    // substitute your struct name here
    public string StructName = "0x2::devnet_nft::MintNFTEvent";
    
    [Range(0, 100)]
    public uint Count = 50;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetEventsByMoveEventStructName(StructName, Count);
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        var resLines = string.Join(",\n", (IEnumerable<object>) result);
        var resultText = $"[\n{resLines}\n]";
        
        Debug.Log("get events by move event struct name result:  " + resultText);
        Task = null;
    }
}
