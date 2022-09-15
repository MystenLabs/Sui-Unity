using System;
using System.Threading.Tasks;
using SuiDotNet.Client;
using SuiDotNet.Client.Requests;
using UnityEngine;

public class SuiGetObjectTest : MonoBehaviour
{
    public SuiJsonClient Client;
    public Task<SuiObject> GetObjectTask;

    // substitute your preferred Sui node endpoint here, either in code or in Unity inspector
    public String SuiNodeUrl = "http://127.0.0.1:9000";
    // substitute your object ID here
    public String TestObjectId = "0x3ac988444287df888b8f321683f49f4a18337f89";

    void Start()
    {
        var settings = new SuiClientSettings() { BaseUri = SuiNodeUrl };
        Client = new SuiJsonClient(settings);
        
        GetObjectTask = Client.GetObject(TestObjectId);
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
