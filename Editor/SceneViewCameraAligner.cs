using UnityEditor;
using UnityEngine;

namespace KoganeUnityLib
{
	[InitializeOnLoad]
	internal static class SceneViewCameraAligner
	{
		private const string ITEM_NAME = "Edit/Scene View Camera Align";

		static SceneViewCameraAligner()
		{
			EditorApplication.update += OnUpdate;
		}

		[MenuItem( ITEM_NAME )]
		private static void Toggle()
		{
			var isOn = Menu.GetChecked( ITEM_NAME );
			Menu.SetChecked( ITEM_NAME, !isOn );
		}

		private static void OnUpdate()
		{
			var isOn = Menu.GetChecked( ITEM_NAME );

			if ( !isOn ) return;

			var sceneView = SceneView.lastActiveSceneView;

			if ( sceneView == null ) return;

			var sceneCamera = Camera.main;

			if ( sceneCamera == null ) return;

			var sceneViewCamera = sceneView.camera;

			if ( sceneViewCamera == null ) return;

			sceneCamera.transform.position = sceneViewCamera.transform.position;
			sceneCamera.transform.rotation = sceneViewCamera.transform.rotation;
		}
	}
}