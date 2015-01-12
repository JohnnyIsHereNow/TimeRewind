using UnityEngine;
using System.Collections;
#if UNITY_ANDROID || UNITY_IOS || UNITY_WP8
using OnePF;
using System.Collections.Generic;
using UnityEngine.UI;
#endif

public class InAppPurchases: MonoBehaviour{
	#if UNITY_ANDROID || UNITY_IOS || UNITY_WP8
	const string SKU1 = "no_ads";
	const string SKU2 = "more_dust";
	
	string _label = "";
	bool _isInitialized = false;
	Inventory _inventory = null;

	public void NoAds(){

		if(_isInitialized && Application.internetReachability!=NetworkReachability.NotReachable)
		{
			PurchaseNoAds();
		}else {_label="Not initializated";}
	}
	public void MoreDust(){

		if(_isInitialized && Application.internetReachability!=NetworkReachability.NotReachable)
		{
			PurchaseMoreDust();
		}else {_label="Not initializated";}
	}
	private void OnEnable()
	{
		if(Application.internetReachability!=NetworkReachability.NotReachable){
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
	}
	private void OnDisable()
	{
		if( Application.internetReachability!=NetworkReachability.NotReachable){
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
	}
	private void Start()
	{
		if( Application.internetReachability!=NetworkReachability.NotReachable){
		// Map skus for different stores       
			OpenIAB.mapSku(SKU1, OpenIAB_Android.STORE_GOOGLE, "no_ads");
			OpenIAB.mapSku(SKU1, OpenIAB_Android.STORE_AMAZON, "no_ads");
			OpenIAB.mapSku(SKU1, OpenIAB_iOS.STORE, "no_ads");
			OpenIAB.mapSku(SKU1, OpenIAB_WP8.STORE, "no_ads");

			OpenIAB.mapSku(SKU2, OpenIAB_Android.STORE_GOOGLE, "more_dust");
			OpenIAB.mapSku(SKU2, OpenIAB_Android.STORE_AMAZON, "more_dust");
			OpenIAB.mapSku(SKU2, OpenIAB_iOS.STORE, "more_dust");
			OpenIAB.mapSku(SKU2, OpenIAB_WP8.STORE, "more_dust");
		inita ();
		}
	}

	private void inita(){
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
	private void Query(){
		OpenIAB.queryInventory(new string[] { SKU1 });
		OpenIAB.queryInventory(new string[] { SKU2 });
	}
	private void PurchaseNoAds(){
		OpenIAB.purchaseProduct(SKU1);
	}
	private void PurchaseMoreDust(){
		OpenIAB.purchaseProduct(SKU2);
	}
	private void Consume(){
	if (_inventory != null && _inventory.HasPurchase(SKU1))
		OpenIAB.consumeProduct(_inventory.GetPurchase(SKU1));
	if (_inventory != null && _inventory.HasPurchase(SKU2))
		OpenIAB.consumeProduct(_inventory.GetPurchase(SKU2));
	}
	private void TestPurchase(){
		OpenIAB.purchaseProduct("android.test.purchased");
	}
	private void TestConsume(){
		if (_inventory != null && _inventory.HasPurchase("android.test.purchased"))
			OpenIAB.consumeProduct(_inventory.GetPurchase("android.test.purchased"));
	}
	private void TestUn(){
		OpenIAB.purchaseProduct("android.test.item_unavailable");
	}
	private void TestCancelled(){
		OpenIAB.purchaseProduct("android.test.canceled");
	}

//============================================================
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
	#endif
}

