Public Class Form1
    Private Structure DatStruct
        Public Cedula As Long
        Public Nombres As String
        Public Edad As Byte
        Public Apellidos As String
    End Structure
    Dim DatPers() As DatStruct
    Dim Index As Int32
    Sub Limpiar_Cajas()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ReDim Preserve DatPers(UBound(DatPers) + 1)
        Catch ex As Exception
            ReDim Preserve DatPers(1)
        End Try
        Index = UBound(DatPers)
        Label6.Text = UBound(DatPers)
        With DatPers(UBound(DatPers))
            .Cedula = TextBox1.Text
            .Apellidos = TextBox2.Text
            .Nombres = TextBox3.Text
            .Edad = TextBox4.Text
        End With
        Label5.Text = "Datos almacenados con éxito"
        Call Limpiar_Cajas()
        TextBox1.Focus()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label5.Text = ""
        Label6.Text = ""
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label5.Text = ""
        Timer1.Enabled = False
    End Sub
    Private Sub Label5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.TextChanged
        Timer1.Enabled = True
    End Sub
    Private Sub Anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Anterior.Click
        If Index > 1 Then
            Index -= 1
            Label6.Text = Index & " / " & UBound(DatPers)
            With DatPers(Index)
                TextBox1.Text = .Cedula
                TextBox2.Text = .Apellidos
                TextBox3.Text = .Nombres
                TextBox4.Text = .Edad
            End With
        Else
            Label5.Text = "Inicio de archivo encontrado"
            Beep()
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Index < UBound(DatPers) Then
            Index += 1
            Label6.Text = Index & " / " & UBound(DatPers)
            With DatPers(Index)
                TextBox1.Text = .Cedula
                TextBox2.Text = .Apellidos
                TextBox3.Text = .Nombres
                TextBox4.Text = .Edad
            End With
        Else
            Label5.Text = "Inicio de archivo encontrado"
            Beep()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim FleNme As String = Mid(Application.ExecutablePath, 1, InStrRev(Application.ExecutablePath, "\")) & "DatPers.Txt"
        FileOpen(1, FleNme, OpenMode.Binary)
        FilePut(1, UBound(DatPers))
        FilePut(1, DatPers)
        FileClose(1)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim FleNme As String = Mid(Application.ExecutablePath, 1, InStrRev(Application.ExecutablePath, "\")) & "DatPers.Txt"
        FileOpen(1, FleNme, OpenMode.Binary)
        FileGet(1, Index)
        ReDim DatPers(Index)
        FileGet(1, DatPers)
        FileClose(1)
        Label6.Text = UBound(DatPers)
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Select Case Asc(e.KeyChar)
            Case Is = 8
            Case Is = 13
                TextBox3.Focus()
            Case Is = 27
                TextBox1.Focus()
            Case Else
                If InStr("1234567890", e.KeyChar) = 0 Then
                    Beep()
                    e.Handled = True
                End If
        End Select
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        Select Case Asc(e.KeyChar)
            Case Is = 8
            Case Is = 13
                TextBox3.Focus()
            Case Is = 27
                TextBox1.Focus()
            Case Else
                If InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ '.", UCase(e.KeyChar)) = 0 Then
                    Beep()
                    e.Handled = True
                Else
                    e.KeyChar = UCase(e.KeyChar)
                End If
        End Select
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        Select Case Asc(e.KeyChar)
            Case Is = 8
            Case Is = 13
                TextBox3.Focus()
            Case Is = 27
                TextBox1.Focus()
            Case Else
                If InStr("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ '.", UCase(e.KeyChar)) = 0 Then
                    Beep()
                    e.Handled = True
                Else
                    'e.KeyChar = UCase(e.KeyChar)
                    If Mid(TextBox3.Text, TextBox3.SelectionStart()) = " " Then
                        e.KeyChar = UCase(e.KeyChar)
                    Else
                        e.KeyChar = LCase(e.KeyChar)
                    End If
                End If
        End Select
    End Sub
End Class


