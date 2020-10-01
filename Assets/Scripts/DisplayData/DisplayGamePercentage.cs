using UnityEngine;
using UnityEngine.UI;


public class DisplayGamePercentage : MonoBehaviour
{
	[SerializeField] private Text percentageText;
	[SerializeField] private GamePercentage gamePercentage;

	private void Update()
	{
		percentageText.text = gamePercentage.RealPercentage.ToString("0.0") + "%";
	}
}
