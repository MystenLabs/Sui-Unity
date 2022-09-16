# Sui-Unity
Unity project for developing Sui's in-progress Unity SDK.

## Dependencies

`SuiDotNet.Client` must be built for the `netstandard2.1` .NET target.

This should produce 4 .DLL files to copy into in `/Assets/Plugins/`:

* `SuiDotNet.Client`
* `Nethereum.JsonRpc.Client`
* `Nethereum.JsonRpc.RpcClient`
* `Common.Logging.Core`

When `SuiDotNet.Client` is changed, the copies in the Unity project must be updated.

## Basic Testing
Open the `BasicRpcTest` scene.

On the "RPC Tests" object, there are a few sub-objects which contain very basic read method test scripts, categorized by data type.  Run the scene with the tests you want enabled to make requests and see results in the debug console/

<img width="767" alt="image" src="https://user-images.githubusercontent.com/14057748/190684656-2f18aeb6-0c8d-4cb0-9df4-86e133f37040.png">

The default values for transaction digests, objects, addresses etc. in the tests will likely _not produce anything on your network_ - they must be changed to known values from your Sui instance.
