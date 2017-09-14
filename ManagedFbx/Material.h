#pragma once

#include "SceneObject.h"

namespace ManagedFbx
{
	public ref class Material : SceneObject
	{
	public:
		/// <summary>
		/// Gets the shading model.
		/// </summary>
		property_r(string^, ShadingModel);
	internal:
		Material(FbxSurfaceMaterial *nativeMaterial);
	private:
		FbxSurfaceMaterial *m_nativeMaterial;
	};
}