Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Web

Public Class ResourceDataSourceHelper
    Public Sub New()
    End Sub

    Public Shared Function GetCustomResources() As List(Of CustomResource)
        Dim list As New List(Of CustomResource)()
        list.Add(New CustomResource() With {.Caption = "Resource 1", .Color = Color.LightCoral, .ResourceId = 1})
        list.Add(New CustomResource() With {.Caption = "Resource 2", .Color = Color.LightGreen, .ResourceId = 2})
        list.Add(New CustomResource() With {.Caption = "Resource 3", .Color = Color.LightYellow, .ResourceId = 3})

        Return list
    End Function
End Class

Public Class CustomResource
    Public Sub New()
    End Sub

    Private privateCaption As String
    Public Property Caption() As String
        Get
            Return privateCaption
        End Get
        Set(ByVal value As String)
            privateCaption = value
        End Set
    End Property
    Private privateColor As Color
    Public Property Color() As Color
        Get
            Return privateColor
        End Get
        Set(ByVal value As Color)
            privateColor = value
        End Set
    End Property
    Private privateResourceId As Integer
    Public Property ResourceId() As Integer
        Get
            Return privateResourceId
        End Get
        Set(ByVal value As Integer)
            privateResourceId = value
        End Set
    End Property
End Class