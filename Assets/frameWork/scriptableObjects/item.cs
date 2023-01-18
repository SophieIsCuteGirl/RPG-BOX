using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "RPG/item")]
public class item : ScriptableObject
{
	public string Name;
	public string Description;
	public float Value;
	public float Weight;
}
