using UnityEngine;

namespace JCMG.Utility
{
	/// <summary>
	/// Helper methods for <see cref="CanvasGroup"/>.
	/// </summary>
	public static class CanvasGroupExtensions
	{
		/// <summary>
		/// Toggles visibility and input for this <see cref="CanvasGroup"/>.
		/// </summary>
		public static void ToggleVisibilityAndInput(this CanvasGroup canvasGroup, bool isVisibleAndAllowsInput)
		{
			canvasGroup.interactable = isVisibleAndAllowsInput;
			canvasGroup.blocksRaycasts = isVisibleAndAllowsInput;
			canvasGroup.alpha = isVisibleAndAllowsInput ? 1 : 0;
		}
	}
}
