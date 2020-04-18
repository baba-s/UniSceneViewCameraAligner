using UnityEditor;
using UnityEngine;

namespace UniSceneViewCameraAligner
{
	/// <summary>
	/// Scene ビューと Game ビューのカメラを同期するエディタ拡張
	/// </summary>
	[InitializeOnLoad]
	internal static class SceneViewCameraAligner
	{
		//================================================================================
		// 定数
		//================================================================================
		private const string ITEM_NAME = "Edit/UniSceneViewCameraAligner/Scene ビューと Game ビューのカメラを同期";

		//================================================================================
		// 関数（static）
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		static SceneViewCameraAligner()
		{
			EditorApplication.update += OnUpdate;
		}

		/// <summary>
		/// Unity メニューからカメラを同期するかどうかを変更します
		/// </summary>
		[MenuItem( ITEM_NAME )]
		private static void Toggle()
		{
			var isOn = Menu.GetChecked( ITEM_NAME );
			Menu.SetChecked( ITEM_NAME, !isOn );
		}

		/// <summary>
		/// Scene ビューと Game ビューのカメラを同期します
		/// </summary>
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

			var sceneCameraTransform     = sceneCamera.transform;
			var sceneViewCameraTransform = sceneViewCamera.transform;

			sceneCameraTransform.position = sceneViewCameraTransform.position;
			sceneCameraTransform.rotation = sceneViewCameraTransform.rotation;
		}
	}
}