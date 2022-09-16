using System;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;
using UnityEngine;

[RequireComponent(typeof(SuiClient))]
public class SuiGetObjectTest : MonoBehaviour
{
    public Task<SuiObject> GetObjectTask;

    // substitute your object ID here
    public String TestObjectId = "0x3ac988444287df888b8f321683f49f4a18337f89";

    void Start()
    {
        var client = gameObject.GetComponent<SuiClient>();
        GetObjectTask = client.Rpc.GetObject(TestObjectId);
    }

    void Update()
    {
        if (GetObjectTask is not {IsCompleted: true})
            return;
        
        Debug.Log("owner type: " + GetObjectTask.Result.Owner.Type);
        Debug.Log("owner address: " + GetObjectTask.Result.Owner.Address);
        Debug.Log("object type: " + GetObjectTask.Result.Data.Type);
        Debug.Log("object digest: " + GetObjectTask.Result.Reference.Digest);
        Debug.Log("previous tx: " + GetObjectTask.Result.PreviousTransaction);
        Debug.Log("storage rebate: " + GetObjectTask.Result.StorageRebate);
        GetObjectTask = null;
    }
}
