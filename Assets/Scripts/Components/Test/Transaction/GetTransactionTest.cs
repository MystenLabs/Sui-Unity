using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetTransactionTest : MonoBehaviour
{
    public Task<SuiTransactionResponse> GetTransactionTask;

    // substitute your transaction digest here
    public String Digest = "XbyTWT8UZ1qXEM4/sdRLOzF+uwtHEEjuoj8m0VKVZFQ=";

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        GetTransactionTask = client.Rpc.GetTransactionWithEffects(Digest);
    }

    void Update()
    {
        if (GetTransactionTask is not {IsCompleted: true}) 
            return;
        
        var result = GetTransactionTask.Result;
        
        Debug.Log("get tx - result:  " + result);
        Debug.Log("get tx, time: " + result.Timestamp);
        Debug.Log("get tx, parsed: " + result.ParsedData);
        
        //Debug.Log("get tx - effects: " + result.Effects);
        Debug.Log("get tx - effects.status.status: " + result.Effects.Status.Status);
        Debug.Log("get tx - effects.transactionDigest: " + result.Effects.TransactionDigest);
        Debug.Log("get tx - effects.gasUsed: " + result.Effects.GasUsed);
        Debug.Log("get tx - effects.gasObject: " + result.Effects.GasObject);
        Debug.Log("get tx - effects.created: " + result.Effects.Created);
        Debug.Log("get tx - effects.mutated: " + result.Effects.Mutated);
        Debug.Log("get tx - effects.events: " + result.Effects.Events);
        
        Debug.Log("get tx - cert TYPE:  " + result.Certificate.GetType());
        Debug.Log("get tx - cert:  " + result.Certificate);
        Debug.Log("get tx - cert.authSignInfo:  " + ((JObject)result.Certificate)["authSignInfo"]);
        Debug.Log("get tx - cert.data:  " + ((JObject)result.Certificate)["data"]);

        /*
        var cert = result.Certificate;
        Debug.Log("get tx - cert, digest: " + cert.TransactionDigest);  
        Debug.Log("get tx - cert, signature: " + cert.Signature);
        Debug.Log("get tx - cert, data: " + cert.Data);
        Debug.Log("get tx - cert, authSignInfo:\n" + cert.AuthoritySignInfo);
        */

        GetTransactionTask = null;
    }
}
