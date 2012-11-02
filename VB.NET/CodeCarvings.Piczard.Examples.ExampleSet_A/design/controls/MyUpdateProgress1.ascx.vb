﻿' -------------------------------------------------------
' Piczard Examples | ExampleSet -A- VB.NET
' Copyright 2011-2012 Sergio Turolla - All Rights Reserved.
' Author: Sergio Turolla
' <codecarvings.com>
'  
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF 
' ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
' PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT 
' SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR 
' ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN 
' ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
' OR OTHER DEALINGS IN THE SOFTWARE.
' -------------------------------------------------------

Partial Class design_controls_MyUpdateProgress1
    Inherits System.Web.UI.UserControl

    Public Property AssociatedUpdatePanelID() As String
        Get
            Return Me.UpdateProgress1.AssociatedUpdatePanelID
        End Get
        Set(ByVal value As String)
            Me.UpdateProgress1.AssociatedUpdatePanelID = value
        End Set
    End Property

End Class
