#pragma once

using namespace System::Collections::Generic;

namespace ManagedFbx
{
	/// <summary>
	/// Represents a property of a node.
	/// </summary>
	public ref class NodeProperty
	{
	public:
		/// <summary>
		/// Gets a value indicating whether it was a source property.
		/// </summary>
		property_r(bool, IsSource);

		/// <summary>
		/// Gets a value indicating whether it was a destination property.
		/// </summary>
		property_r(bool, IsDestination);

		/// <summary>
		/// Gets a value indicating whether it was a user defined property.
		/// </summary>
		property_r(bool, IsUserDefined);

		/// <summary>
		/// Gets the name of the property.
		/// </summary>
		property_r(string^, Name);

		/// <summary>
		/// Gets the dataType of the property.
		/// </summary>
		property_r(string^, DataType);

		/// <summary>
		/// Gets the value of the property.
		/// </summary>
		property_r(string^, Value);
	internal:
		NodeProperty(FbxProperty prop, bool source, bool destination);

	private:
		string^ m_Name;
		string^ m_DataType;
		string^ m_Value;
		bool m_isSource;
		bool m_isDestination;
		bool m_isUserDefined;
	};
}
