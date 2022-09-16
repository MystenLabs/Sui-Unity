using System;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetTransactionsForAddressTest : MonoBehaviour
{
    public Task<SequencedTransaction[]> GetTransactionsForAddressTask;

    // substitute your test address here
    public String TestAddress = "0x08c9e31048ce86a3538272d4adaf2069ecf26c01";

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        GetTransactionsForAddressTask = client.Rpc.GetTransactionsForAddress(TestAddress);
    }

    void Update()
    {
        if (GetTransactionsForAddressTask is not {IsCompleted: true}) 
            return;
        
        Debug.Log("tx for address count: " + GetTransactionsForAddressTask.Result.Length);
        foreach (var addrTx in GetTransactionsForAddressTask.Result)
            Debug.Log("get tx for address result: [" + addrTx.SequenceNumber + ", " + addrTx.Digest + "]");
        
        GetTransactionsForAddressTask = null;
    }
}
