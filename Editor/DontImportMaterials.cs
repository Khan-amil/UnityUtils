﻿using UnityEditor;

namespace Utils.Editor
{
	public class DontImportMaterials : AssetPostprocessor
	{
		public void OnPreprocessModel()
		{
			ModelImporter modelImporter = (ModelImporter) assetImporter;                    
			modelImporter.importMaterials = false ;         
		}

	}
}