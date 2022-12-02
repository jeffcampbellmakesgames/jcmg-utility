using UnityEngine;
using UnityEngine.UI;

namespace JCMG.Utility
{
	/// <summary>
	/// A <see cref="UnityEngine.UI.Graphic"/> that skips drawing. Useful for providing a raycast target without
	/// drawing anything.
	/// <remarks>See https://gist.github.com/capnslipp/349c18283f2fea316369 for reference.</remarks>
	/// </summary>
	[RequireComponent(typeof(CanvasRenderer))]
	public class NonDrawingGraphic : Graphic
	{
		/// <inheritdoc />
		public override void SetMaterialDirty()
		{
			// No-Op
		}

		/// <inheritdoc />
		public override void SetVerticesDirty()
		{
			// No-Op
		}

		/// <inheritdoc />
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			// Prevents mesh from populating. Serves as a fail-safe in case the mesh is rebuilt.
			vh.Clear();
		}
	}
}
