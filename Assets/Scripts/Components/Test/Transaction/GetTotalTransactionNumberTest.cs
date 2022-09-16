using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetTotalTransactionNumberTest : MonoBehaviour
{
    Task<ulong> Task;

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        Task = client.Rpc.GetTotalTransactionNumber();
    }

    void Update()
    {
        if (Task is not {IsCompleted: true}) 
            return;
        
        var result = Task.Result;
        Debug.Log("get total transaction count:  " + result);
        Task = null;
    }
}
