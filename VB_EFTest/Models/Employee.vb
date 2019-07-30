 Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.CompilerServices

    Public Class Employee
        Public Property [Alias] As String
        Public Property HomeEmail As String
        Public Property ID As Integer
        <MaxLength(11)>
        Public Property Mobile As String
        Public Property Name As String
        Public Property Remarks As String
        Public Sub New()
            MyBase.New()
        End Sub
    End Class
