using UnityEngine;

[CreateAssetMenu]
public class DeveloperStates : CharacterStates
{
	public float Speed { get; set; }

	public bool IsDistracted { get; set; }
	public bool Stand { get; set; }
	public bool Asleep { get; set; }
	public bool Programming { get; set; }
	public bool GhostOnPc { get; set; }

	public override void ResetData()
	{
		base.ResetData();

		Speed = 0;
		IsDistracted = false;
		Stand = false;
		Asleep = false;
		Programming = false;
	}
}
