using System;
using SuiDotNet.Client;
using UnityEngine;

public class SuiClient : MonoBehaviour
{
    public SuiJsonClient Rpc;

    // substitute your preferred Sui node endpoint here, either in code or in Unity inspector
    public String SuiNodeUrl = "http://127.0.0.1:9000";

    // use Awake instead of Start so this runs before things that depend on it
    void Awake()
    {
        var settings = new SuiClientSettings { BaseUri = SuiNodeUrl };
        Rpc = new SuiJsonClient(settings);
    }
}
