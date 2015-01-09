using UnityEngine;
using System.Collections;

public class Mission {
	string name="", description="";
	int id=-1, toComplete=-1,completed=0;

	public Mission(int id,string name, string description, int toComplete){
		this.id=id;
		this.name=name;
		this.description=description;
		this.toComplete=toComplete;
		saveData();
	}
	public string getName(){return name;}
	public int getId(){return id;}
	public void saveData(){
		PlayerPrefs.SetString(""+id,""+id+","+name+","+description+","+toComplete+","+completed);
	}

}
