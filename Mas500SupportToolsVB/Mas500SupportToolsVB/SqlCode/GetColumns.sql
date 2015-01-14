SELECT 
		OBJECT_NAME([object_id]) AS ObjectName, [Name], Column_ID, 
		System_Type_ID, Max_Length, Precision, Scale, Collation_Name, 
		Is_Nullable, Is_RowGuidCol, Is_Identity 
FROM sys.columns col
ORDER BY Objectname, [Name]