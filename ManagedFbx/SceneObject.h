#pragma once

#include "NodeProperty.h"

using namespace System;
using namespace System::Collections::Generic;

namespace ManagedFbx
{
	[System::Flags]
	public enum class ObjectFlag : int
	{
		None = FbxObject::EObjectFlag::eNone,
		Initialized = FbxObject::EObjectFlag::eInitialized,
		System = FbxObject::EObjectFlag::eSystem,
		Savable = FbxObject::EObjectFlag::eSavable,
		Selected = FbxObject::EObjectFlag::eSelected,
		Hidden = FbxObject::EObjectFlag::eHidden,
		ContentLoaded = FbxObject::EObjectFlag::eContentLoaded,
		DontLocalize = FbxObject::EObjectFlag::eDontLocalize,
		CopyCalledByClone = FbxObject::EObjectFlag::eCopyCalledByClone
	};

	/// <summary>
	/// Represents a single node in the FBX scene graph.
	/// </summary>
	public ref class SceneObject
	{
	public:
		/// <summary>
		/// Gets and sets the name of this node.
		/// </summary>
		property_rw(string^, Name);

		/// <summary>
		/// Gets the flags for this node.
		/// </summary>
		property_r(ObjectFlag, Flags);

		/// <summary>
		/// Gets a collection of FBX properties for this node.
		/// </summary>
		property_r(IEnumerable<NodeProperty^>^, Properties);

	internal:
		SceneObject(FbxObject *nativeObject);
		FbxObject *m_nativeObject;

	private:
		List<NodeProperty^> ^m_properties;
	};
}