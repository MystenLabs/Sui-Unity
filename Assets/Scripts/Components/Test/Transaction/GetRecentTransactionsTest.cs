using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetRecentTransactionsTest : MonoBehaviour
{
    Task<SequencedTransaction[]> Task;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetRecentTransactions();
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        var resLines = string.Join(",\n\t", (IEnumerable<SequencedTransaction>) result);
        var resultText = $"[\n\t{resLines}\n]";
        Debug.Log("get recent transactions result:\n" + resultText);
        Task = null;
    }
}
