Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.Windows.Forms.Design

<Designer(GetType(SeparatorDesigner))>
Public Class Separator

    Public Enum enmOrientation
        Horizontal
        Vertical
    End Enum

    Public Sub New()
        InitializeComponent()
        Me.Height = 2
    End Sub

    Private _Color1 As Color = SystemColors.ControlDark
    <DefaultValue(GetType(Color), "ControlDark")>
    Public Property Color1() As Color
        Get
            Return _Color1
        End Get
        Set(ByVal value As Color)
            _Color1 = value
        End Set
    End Property

    Private _Color2 As Color = Color.White
    <DefaultValue(GetType(Color), "White")>
    Public Property Color2() As Color
        Get
            Return _Color2
        End Get
        Set(ByVal value As Color)
            _Color2 = value
        End Set
    End Property

    Private _Orientation As enmOrientation = enmOrientation.Horizontal
    <DefaultValue(enmOrientation.Horizontal)>
    Public Property Orientation() As enmOrientation
        Get
            Return _Orientation
        End Get
        Set(ByVal value As enmOrientation)
            _Orientation = value

            'Swap width and height
            If value = enmOrientation.Horizontal Then
                Me.Width = Me.Height
                Me.Height = 2
            Else
                Me.Height = Me.Width
                Me.Width = 2
            End If
        End Set
    End Property

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        If Me.Orientation = enmOrientation.Horizontal Then
            Me.Height = 2
        Else
            Me.Width = 2
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(e)

        If Me.Orientation = enmOrientation.Horizontal Then
            e.Graphics.DrawLine(New Pen(Me.Color1), 0, 0, Me.Width, 0)
            e.Graphics.DrawLine(New Pen(Me.Color2), 0, 1, Me.Width, 1)
        Else
            e.Graphics.DrawLine(New Pen(Me.Color1), 0, 0, 0, Me.Height)
            e.Graphics.DrawLine(New Pen(Me.Color2), 1, 0, 1, Me.Height)
        End If
    End Sub

End Class

Public Class SeparatorDesigner
    Inherits System.Windows.Forms.Design.ControlDesigner

    Private lists As DesignerActionListCollection

    'Retrieves the Separator control to which this designer belongs
    Private ReadOnly Property HostControl() As Separator
        Get
            Return DirectCast(Me.Control, Separator)
        End Get
    End Property

    'Adds the Action Lists (> menu) 
    Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
        Get
            If lists Is Nothing Then
                lists = New DesignerActionListCollection()
                lists.Add(New SeparatorActionList(Me.Component))
            End If
            Return lists
        End Get
    End Property

    'Allows only horizontal/vertical resizing
    Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
        Get
            Dim selRules As SelectionRules = Windows.Forms.Design.SelectionRules.Moveable

            If Me.HostControl.Orientation = Separator.enmOrientation.Horizontal Then
                selRules = selRules Or Windows.Forms.Design.SelectionRules.LeftSizeable Or
                                       Windows.Forms.Design.SelectionRules.RightSizeable
            Else
                selRules = selRules Or Windows.Forms.Design.SelectionRules.TopSizeable Or
                                       Windows.Forms.Design.SelectionRules.BottomSizeable
            End If

            Return selRules
        End Get
    End Property

    Protected Overrides Sub PostFilterProperties(ByVal properties As System.Collections.IDictionary)
        properties.Remove("BackColor")
        properties.Remove("BackgroundImage")
        properties.Remove("BackgroundImageLayout")
        properties.Remove("BorderStyle")
        properties.Remove("Font")
        properties.Remove("ForeColor")
        properties.Remove("RightToLeft")
        MyBase.PostFilterProperties(properties)
    End Sub

    'The class that shows the Action List (> menu) properties
    Public Class SeparatorActionList
        Inherits DesignerActionList

        Private _sep As Separator
        Private designerActionSvc As DesignerActionUIService = Nothing

        Public Sub New(ByVal component As IComponent)
            MyBase.New(component)
            _sep = DirectCast(component, Separator)

            Me.designerActionSvc = CType(GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
        End Sub

        Public Property Color1() As Color
            Get
                Return _sep.Color1
            End Get
            Set(ByVal value As Color)
                _sep.Color1 = value
            End Set
        End Property

        Public Property Color2() As Color
            Get
                Return _sep.Color2
            End Get
            Set(ByVal value As Color)
                _sep.Color2 = value
            End Set
        End Property

        Public Property Orientation() As Separator.enmOrientation
            Get
                Return _sep.Orientation
            End Get
            Set(ByVal value As Separator.enmOrientation)
                _sep.Orientation = value
            End Set
        End Property

        Public Sub SwapColors()
            Dim c As Color = _sep.Color1
            _sep.Color1 = _sep.Color2
            _sep.Color2 = c
            designerActionSvc.Refresh(_sep)
        End Sub

        Public Overrides Function GetSortedActionItems() As System.ComponentModel.Design.DesignerActionItemCollection
            Dim items As New DesignerActionItemCollection

            items.Add(New DesignerActionHeaderItem("Properties"))
            items.Add(New DesignerActionPropertyItem("Color1", "Color1:", "Properties", "The top/left color."))
            items.Add(New DesignerActionPropertyItem("Color2", "Color2:", "Properties", "The bottom/right color."))
            items.Add(New DesignerActionPropertyItem("Orientation", "Orientation:", "Properties", "The orientation of the separator."))
            items.Add(New DesignerActionMethodItem(Me, "SwapColors", "Swap colors", "Properties", "Swaps the two colors.", True))

            Return (items)
        End Function
    End Class

End Class