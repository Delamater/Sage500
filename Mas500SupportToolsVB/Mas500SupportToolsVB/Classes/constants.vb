Option Explicit On
Option Strict On

Class constants

    'Row State Colors
    Public rowStateModified As Color = Color.Crimson
    'Public rowStateUnchanged As Color = Color.White
    Public rowStateDeleted As Color = Color.BurlyWood
    Public rowstateAdded As Color = Color.LightBlue


    Public AlternatingRowBackColor As Color = Color.Bisque

    'Strings
    Public Const kRequiredFiles As String = "Please ensure the base and destination files have been selected prior to requesting a file comparison"
    Public Const kAllUserConfigFileLocation As String = "C:\Documents and Settings\All Users\Application Data\Sage Software\Sage MAS 500\Application.Config"
    Public Const kSchemaIsNotCorrect As String = "One or both of the files selected do not have the correct schema definition. Please regenerate your source files for comparison or choose source files that have the correct schema."
    Public Const kInvalidSqlStatement As String = "Invalid SQL Statement"
End Class
