SELECT 
		OBJECT_NAME([object_id]) AS ObjectName, [Name], 
		Index_Id, [Type], Type_Desc, Is_Unique,
		Is_Primary_Key, Is_Unique_Constraint, Fill_Factor
FROM sys.Indexes ind