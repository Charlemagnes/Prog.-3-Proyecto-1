Public Class Form1
    Private Structure DatStruct
        Public Placa As String
        Public Marca_carro As String
        Public Cedula As Long
        Public Nombre As String
        Public Apellido As String
    End Structure
    Dim Datpers() As DatStruct
    Dim Index As Int32
    Sub limpiador()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label7.Text = ""
        Label8.Text = ""
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label8.Text = ""
        Timer1.Enabled = False
    End Sub
    Private Sub Label8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.TextChanged
        Timer1.Enabled = True
    End Sub
    'Aceptar
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            ReDim Preserve Datpers(UBound(Datpers) + 1)
        Catch ex As Exception
            ReDim Preserve Datpers(1)
        End Try
        Index = UBound(Datpers)
        Label7.Text = UBound(Datpers)
        With Datpers(UBound(Datpers))
            .Placa = TextBox1.Text
            .Marca_carro = TextBox2.Text
            .Cedula = TextBox3.Text
            .Nombre = TextBox4.Text
            .Apellido = TextBox5.Text
        End With
        Label8.Text = "¡Datos almacenados con éxito!"
        Call limpiador()
        TextBox1.Focus()
    End Sub
    'Anterior
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Index > 1 Then
            Index -= 1
            Label7.Text = Index & " / " & UBound(Datpers)
            With Datpers(Index)
                TextBox1.Text = .Placa
                TextBox2.Text = .Marca_carro
                TextBox3.Text = .Cedula
                TextBox4.Text = .Nombre
                TextBox5.Text = .Apellido
            End With
        Else
            Label8.Text = "¡Inicio de Archivo Encontrado!"
            Beep()
        End If
    End Sub
    'Siguiente
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Index < UBound(Datpers) Then
            Index += 1
            Label7.Text = Index & " / " & UBound(Datpers)
            With Datpers(Index)
                TextBox1.Text = .Placa
                TextBox2.Text = .Marca_carro
                TextBox3.Text = .Cedula
                TextBox4.Text = .Nombre
                TextBox5.Text = .Apellido
            End With
        Else
            Label8.Text = "¡Final de Archivo Encontrado!"
            Beep()
        End If
    End Sub
    'Salvar
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

    End Sub
    'Cargar
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class
