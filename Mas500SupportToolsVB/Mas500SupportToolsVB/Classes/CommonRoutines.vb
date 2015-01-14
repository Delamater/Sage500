Option Explicit On
Option Strict On

Imports System.Text

Public Class CommonRoutines

    ''' <summary>
    ''' Displays a common messagesbox
    ''' </summary>
    ''' <param name="ex">Provide a reference to the exception object</param>
    ''' <param name="icon">Set the MessageBoxIcon type</param>
    ''' <param name="buttons">Set the MessageBoxButton</param>
    ''' <remarks></remarks>
    Public Sub ShowMessageBox(ByVal ex As Exception, _
                              ByVal icon As MessageBoxIcon, _
                              ByVal buttons As MessageBoxButtons)

        Dim strErrMsg As New StringBuilder()
        strErrMsg.AppendLine(ex.GetType().UnderlyingSystemType.FullName.ToString())
        strErrMsg.AppendLine()
        strErrMsg.AppendLine(ex.Message)

        Select Case icon
            Case MessageBoxIcon.Error, MessageBoxIcon.Exclamation, _
                MessageBoxIcon.Stop, MessageBoxIcon.Hand

                strErrMsg.AppendLine()
                strErrMsg.AppendLine(ex.StackTrace)

        End Select

        MessageBox.Show(strErrMsg.ToString(), _
                        Application.ProductName.ToString(), _
                        MessageBoxButtons.OK, _
                        icon)

    End Sub

    ''' <summary>
    ''' Displays a common messagebox.
    ''' </summary>
    ''' <param name="strMessage">Provide a string message</param>
    ''' <param name="icon">Set the MessageBoxIcon type</param>
    ''' <param name="buttons">Set the MessageBoxButton</param>
    ''' <remarks></remarks>
    Public Sub ShowMessageBox(ByVal strMessage As String, _
                              ByVal icon As MessageBoxIcon, _
                              ByVal buttons As MessageBoxButtons)

        Dim strErrMsg As New StringBuilder()
        strErrMsg.AppendLine(strMessage)

        Select Case icon
            Case MessageBoxIcon.Error, MessageBoxIcon.Exclamation, _
                MessageBoxIcon.Stop, MessageBoxIcon.Hand

                strErrMsg.AppendLine()
                strErrMsg.AppendLine(Environment.StackTrace)

        End Select

        MessageBox.Show(strErrMsg.ToString(), _
                        Application.ProductName.ToString(), _
                        MessageBoxButtons.OK, _
                        icon)

    End Sub
End Class
