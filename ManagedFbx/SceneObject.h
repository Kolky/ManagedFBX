#pragma once

#include "NodeProperty.h"

using namespace System::Collections::Generic;

namespace ManagedFbx
{
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