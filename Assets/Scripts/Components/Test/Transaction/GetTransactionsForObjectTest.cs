using System;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetTransactionsForObjectTest : MonoBehaviour
{
    public Task<SequencedTransaction[]> GetTransactionsForObjectTask;

    // substitute your test object id here
    public String TestObject = "0x0754d12ea8d4698cb861d11cb192574b53c19925";

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        GetTransactionsForObjectTask = client.Rpc.GetTransactionsForObject(TestObject);
    }

    void Update()
    {
        if (GetTransactionsForObjectTask is not {IsCompleted: true})
            return;
        
        Debug.Log("tx for object count: " + GetTransactionsForObjectTask.Result.Length);
        foreach (var objTx in GetTransactionsForObjectTask.Result)
            Debug.Log("get tx for object result: [" + objTx.SequenceNumber + ", " + objTx.Digest + "]");
        
        GetTransactionsForObjectTask = null;
    }
}
