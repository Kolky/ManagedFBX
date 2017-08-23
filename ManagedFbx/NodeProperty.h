#pragma once

using namespace System::Collections::Generic;

namespace ManagedFbx
{
	public ref class NodeProperty
	{
	public:
		property_r(bool, IsSource);
		property_r(bool, IsDestination);
		property_r(string^, Name);
		property_r(string^, DataType);
		property_r(string^, Value);
	internal:
		NodeProperty(FbxProperty prop, bool source, bool destination);
		string^ m_Name;
		string^ m_DataType;
		string^ m_Value;
		bool m_isSource;
		bool m_isDestination;
	};
}
