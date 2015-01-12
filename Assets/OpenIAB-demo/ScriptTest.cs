using UnityEngine;
using System.Collections;
using OnePF;
using System.Collections.Generic;
public class ScriptTest : MonoBehaviour {
	const string SKU = "sku";
	
	string _label = "";
	bool _isInitialized = false;
	Inventory _inventory = null;
	
	private void OnEnable()
	{
		// Listen to all events for illustration purposes
		OpenIABEventManager.billingSupportedEvent += billingSupportedEvent;
		OpenIABEventManager.billingNotSupportedEvent += billingNotSupportedEvent;
		OpenIABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		OpenIABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		OpenIABEventManager.purchaseSucceededEvent += purchaseSucceededEvent;
		OpenIABEventManager.purchaseFailedEvent += purchaseFailedEvent;
		OpenIABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		OpenIABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
	}
	private void OnDisable()
	{
		// Remove all event handlers
		OpenIABEventManager.billingSupportedEvent -= billingSupportedEvent;
		OpenIABEventManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		OpenIABEventManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		OpenIABEventManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		OpenIABEventManager.purchaseSucceededEvent -= purchaseSucceededEvent;
		OpenIABEventManager.purchaseFailedEvent -= purchaseFailedEvent;
		OpenIABEventManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		OpenIABEventManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
	}
	private void Start()
	{
		// Map skus for different stores       
		OpenIAB.mapSku(SKU, OpenIAB_Android.STORE_GOOGLE, "sku");
		OpenIAB.mapSku(SKU, OpenIAB_Android.STORE_AMAZON, "sku");
		OpenIAB.mapSku(SKU, OpenIAB_iOS.STORE, "sku");
		OpenIAB.mapSku(SKU, OpenIAB_WP8.STORE, "ammo");
		

		//OpenIAB.purchaseProduct(SKU);
	}


	public void OnGUI(){
		if(GUI.Button(new Rect(0,0,100,100),"Init")){
			// Application public key
			var publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgEEaiFfxugLWAH4CQqXYttXlj3GI2ozlcnWlZDaO2VYkcUhbrAz368FMmw2g40zgIDfyopFqETXf0dMTDw7VH3JOXZID2ATtTfBXaU4hqTf2lSwcY9RXe/Uz0x1nf1oLAf85oWZ7uuXScR747ekzRZB4vb4afm2DsbE30ohZD/WzQ22xByX6583yYE19RdE9yJzFckEPlHuOeMgKOa4WErt11PHB6FTdT5eN96/jjjeEoYhX/NGkOWKW0Y0T0A7CdUC0D4t2xxkzAQHdgLfcRw9+/EIcaysLhncWYiCifJrRBGpqZU1IrNuehrC5FXUN99786c/TwlxNG5nflE6sWwIDAQAB";
			
			var options = new Options();
			options.checkInventoryTimeoutMs = Options.INVENTORY_CHECK_TIMEOUT_MS * 2;
			options.discoveryTimeoutMs = Options.DISCOVER_TIMEOUT_MS * 2;
			options.checkInventory = false;
			options.verifyMode = OptionsVerifyMode.VERIFY_SKIP;
			options.prefferedStoreNames = new string[] { OpenIAB_Android.STORE_GOOGLE };
			options.availableStoreNames = new string[] { OpenIAB_Android.STORE_GOOGLE };
			options.storeKeys = new Dictionary<string, string> { {OpenIAB_Android.STORE_GOOGLE, publicKey} };
			options.storeSearchStrategy = SearchStrategy.INSTALLER_THEN_BEST_FIT;
			
			// Transmit options and start the service
			OpenIAB.init(options);
		}
		if(GUI.Button(new Rect(0,100,100,100),"Buy")){
			OpenIAB.purchaseProduct(SKU);
		}

	}
private void billingSupportedEvent()
{
	_isInitialized = true;
	Debug.Log("billingSupportedEvent");
}
private void billingNotSupportedEvent(string error)
{
	Debug.Log("billingNotSupportedEvent: " + error);
}
private void queryInventorySucceededEvent(Inventory inventory)
{
	Debug.Log("queryInventorySucceededEvent: " + inventory);
	if (inventory != null)
	{
		_label = inventory.ToString();
		_inventory = inventory;
	}
}
private void queryInventoryFailedEvent(string error)
{
	Debug.Log("queryInventoryFailedEvent: " + error);
	_label = error;
}
private void purchaseSucceededEvent(Purchase purchase)
{
	Debug.Log("purchaseSucceededEvent: " + purchase);
	_label = "PURCHASED:" + purchase.ToString();
}
private void purchaseFailedEvent(int errorCode, string errorMessage)
{
	Debug.Log("purchaseFailedEvent: " + errorMessage);
	_label = "Purchase Failed: " + errorMessage;
}
private void consumePurchaseSucceededEvent(Purchase purchase)
{
	Debug.Log("consumePurchaseSucceededEvent: " + purchase);
	_label = "CONSUMED: " + purchase.ToString();
}
private void consumePurchaseFailedEvent(string error)
{
	Debug.Log("consumePurchaseFailedEvent: " + error);
	_label = "Consume Failed: " + error;
}
}
