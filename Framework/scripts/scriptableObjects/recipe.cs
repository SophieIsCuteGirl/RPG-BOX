using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "RPG-Box/recipe")]
public class recipe : ScriptableObject
{
	public item[] inputItems;
	public item[] outputItems;
}
