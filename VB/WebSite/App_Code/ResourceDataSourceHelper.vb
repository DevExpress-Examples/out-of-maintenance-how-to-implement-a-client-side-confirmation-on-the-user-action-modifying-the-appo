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
		list.Add(New CustomResource() With {
			.Caption = "Resource 1",
			.Color = Color.LightCoral,
			.ResourceId = 1
		})
		list.Add(New CustomResource() With {
			.Caption = "Resource 2",
			.Color = Color.LightGreen,
			.ResourceId = 2
		})
		list.Add(New CustomResource() With {
			.Caption = "Resource 3",
			.Color = Color.LightYellow,
			.ResourceId = 3
		})

		Return list
	End Function
End Class

Public Class CustomResource
	Public Sub New()
	End Sub

	Public Property Caption() As String
	Public Property Color() As Color
	Public Property ResourceId() As Integer
End Class
