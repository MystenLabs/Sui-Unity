using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class GetTransactionsBatchTest : MonoBehaviour
{
    public Task<SuiTransactionResponse[]> RpcTask;

    // substitute your transaction digests here
    public string[] TestTransactionDigests = {
        "XbyTWT8UZ1qXEM4/sdRLOzF+uwtHEEjuoj8m0VKVZFQ=",
        "pnyn2ylZCxpfHxxUTZbMCt924Jfzg+p24TEtI7Qx5bE=",
        "lCuDStZX86yDPCL8TZWWWwdkPCfyOHEY+dJ6EGwVueU=",
        "1XpVLd9CC70kzLRHwUkZEWBEF62s32DM96FEcNhUOcg=",
        "1b0yipd8FYznQQv12lMmbCxwKCunHhmBGz+GP28o2o4="
    };

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        RpcTask = client.Rpc.GetTransactionWithEffectsBatch(TestTransactionDigests);
    }

    void Update()
    {
        if (RpcTask is not {IsCompleted: true}) 
            return;
        
        var result = RpcTask.Result;
        for (var i = 0; i < result.Length; i++)
        {
            var tx = result[i];
            var cert = tx.Certificate;

            Debug.Log($"get tx batch {i}, digest: " + cert.TransactionDigest);
            Debug.Log($"get tx batch {i}, signature: " + cert.Signature);
            Debug.Log($"get tx batch {i}, data: " + cert.Data);
            Debug.Log($"get tx batch {i}, authSignInfo:\n" + cert.AuthoritySignInfo);
            
            Debug.Log($"get tx batch {i}, time: " + tx.Timestamp);
            Debug.Log($"get tx batch {i}, effects.created length: " + tx.Effects.Created?.Length);
            Debug.Log($"get tx batch {i}, effects.mutated length: " + tx.Effects.Mutated?.Length);
            Debug.Log($"get tx batch {i}, parsed: " + tx.ParsedData);
        }

        RpcTask = null;
    }
}
