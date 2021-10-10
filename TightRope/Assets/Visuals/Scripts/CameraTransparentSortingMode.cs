using UnityEngine;
using UnityEngine.Rendering;
using UnityCamera = UnityEngine.Camera;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Specify transparent sorting mode and axis for camera.
/// </summary>
namespace TightRope.Camera {

	[RequireComponent(typeof(UnityCamera))]
	public class CameraTransparentSortingMode : MonoBehaviour {

		// Inspector vars
#pragma warning disable 0649
		[SerializeField]
		private TransparencySortMode _transparencySortMode = TransparencySortMode.CustomAxis;

		public Vector3 customSortAxis = Vector3.forward;

		public bool setSort = false; // enable sort in inspector to trigger sorting. Will reset to false.

		[SerializeField]
		private OpaqueSortMode _opaqueSortMode;
#pragma warning restore 0649

		// Vars

		#region ---------------------- GETTERS/SETTERS ----------------------
		private UnityCamera _c;
		public UnityCamera sceneCamera {
			get {
				if (_c == null) _c = GetComponent<UnityCamera>();
				return _c;
			}
		}
		#endregion

		#region ---------------------- START FUNCTION -----------------------
		private void Start() {
			DoSort(sceneCamera);
#if UNITY_EDITOR
			SetSortModeForEditorCamera();
#endif
		}
		#endregion

		#region ---------------------- UPDATE FUNCTION ----------------------
		#endregion

		#region --------------------- PUBLIC FUNCTIONS ----------------------
		#endregion

		#region -------------------- PROTECTED FUNCTIONS --------------------
		#endregion

		#region --------------------- PRIVATE FUNCTIONS ---------------------
		private void DoSort(UnityCamera camera) {
			camera.transparencySortMode = _transparencySortMode;
			if (_transparencySortMode == TransparencySortMode.CustomAxis) {
				camera.transparencySortAxis = customSortAxis;
			}
			camera.opaqueSortMode = _opaqueSortMode;
		}

#if UNITY_EDITOR
		private void OnValidate() {
			// ugly ass hack, Marcus. Don't do this.
			DoSort(sceneCamera);
			SetSortModeForEditorCamera();
			setSort = false;
		}

		private void SetSortModeForEditorCamera() {
			if (SceneView.lastActiveSceneView != null) {
				DoSort(SceneView.lastActiveSceneView.camera);
			}
		}

#endif
		#endregion

		#region ------------------------- HANDLERS --------------------------
		#endregion
	}
}

