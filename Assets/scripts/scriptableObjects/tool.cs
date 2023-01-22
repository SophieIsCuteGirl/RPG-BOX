using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "RPG-Box/tool")]
public class tool : ScriptableObject
{
	public string Name;
	public string Description;
	public float Strength;
	public bool useDurability;
	public float Durability;
	public float Value;
	public float Weight;
}
