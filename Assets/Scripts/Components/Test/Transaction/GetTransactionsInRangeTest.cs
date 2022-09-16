using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetTransactionsInRangeTest : MonoBehaviour
{
    Task<SequencedTransaction[]> Task;

    public ulong RangeStart = 5;
    public ulong RangeEnd = 15;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetTransactionDigestsInRange(RangeStart, RangeEnd);
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        var resLines = string.Join(",\n\t", (IEnumerable<SequencedTransaction>) result);
        var resultText = $"[\n\t{resLines}\n]";
        Debug.Log("get transactions in range result:\n" + resultText);
        Task = null;
    }
}
