using System;
using System.Collections.Generic;
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
        Debug.Log("tx - time: " + result.Timestamp);
        if(result.ParsedData != null)
            Debug.Log("tx - parsedData: " + result.ParsedData);
        
        var effects = result.Effects;
        Debug.Log("tx - effects.status.status: " + effects.Status.Status);
        Debug.Log("tx - effects.transactionDigest: " + effects.TransactionDigest);
        Debug.Log("tx - effects.gasUsed: " + effects.GasUsed);
        Debug.Log("tx - effects.gasObject: " + effects.GasObject);

        LogAll(effects.Created, "effects.created members follow...");
        LogAll(effects.Deleted, "effects.deleted members follow...");
        LogAll(effects.Mutated, "effects.mutated members follow...");
        
        LogAll(effects.Events, "effects.events members follow...");
        
        var cert = result.Certificate;
        Debug.Log("tx - cert:  " + cert);

        GetTransactionTask = null;
    }

    static void LogAll<T>(T[] data, string initialLog = null)
    {
        if (data is not {Length: > 0}) 
            return;
        if(initialLog != null)
            Debug.Log(initialLog);
        foreach (var d in data)
            Debug.Log(d);
    }
}
