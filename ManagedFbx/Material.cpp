#include "stdafx.h"
#include "Material.h"

using namespace ManagedFbx;

Material::Material(FbxSurfaceMaterial *nativeMaterial)
	: SceneObject(nativeMaterial)
{
	m_nativeMaterial = nativeMaterial;
}

string ^Material::ShadingModel::get()
{
	return gcnew string(m_nativeMaterial->ShadingModel.Get());
}