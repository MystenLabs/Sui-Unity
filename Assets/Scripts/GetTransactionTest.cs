using System;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetTransactionTest : MonoBehaviour
{
    public Task<SuiTransactionResponse> GetTransactionTask;

    // substitute your transaction digest here
    public String TestTransactionDigest = "XbyTWT8UZ1qXEM4/sdRLOzF+uwtHEEjuoj8m0VKVZFQ=";

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        GetTransactionTask = client.Rpc.GetTransactionWithEffects(TestTransactionDigest);
    }

    void Update()
    {
        if (GetTransactionTask is not {IsCompleted: true}) 
            return;
        
        var result = GetTransactionTask.Result;
        var cert = result.Certificate;
        Debug.Log("get tx - cert, digest: " + cert.TransactionDigest);
        Debug.Log("get tx - cert, signature: " + cert.Signature);
        Debug.Log("get tx - cert, data: " + cert.Data);
        Debug.Log("get tx - cert, authSignInfo:\n" + cert.AuthoritySignInfo);
            
        Debug.Log("get transaction, time: " + result.Timestamp);
        Debug.Log("get transaction, effects: " + JsonUtility.ToJson(result.Effects));
        Debug.Log("get transaction, parsed: " + result.ParsedData);
        GetTransactionTask = null;
    }
}
