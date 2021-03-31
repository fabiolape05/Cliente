Imports System.Data.SqlClient
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        mostrardatos()
    End Sub
    'mostrar datos en el datagrid
    Sub mostrardatos()
        Dim da As New SqlDataAdapter("select * from Cliente", con)
        Dim ds As New DataSet
        da.Fill(ds, "Cliente")
        DataGridView1.DataSource = ds.Tables(0)
        'personalizar el encabezado de  las columnas
        DataGridView1.Columns("Codigo").HeaderText = "Codigo"
        DataGridView1.Columns("Nombre").HeaderText = "Nombre"
        DataGridView1.Columns("Direccion").HeaderText = "Direccion"
        DataGridView1.Columns("Ciudad").HeaderText = "Ciudad"

    End Sub

    Private Sub cmdInsertar_Click(sender As Object, e As EventArgs) Handles cmdInsertar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into Cliente (Codigo,Nombre,Direccion,Ciudad)   values  ('" & txtCodigo.Text & "','" & txtNombre.Text & "','" & txtDireccion.Text & "' ,'" & txtCiudad.Text & "')"
            cmd.ExecuteNonQuery()
            MessageBox.Show("datos guardados")
            mostrardatos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'usaremos el evento rowheadermouseclick 
    End Sub


    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        If DataGridView1.Rows.Count > 0 Then
            'si es mayor que cero entonces tiene datos cargados
            If DataGridView1.SelectedRows.Count > 0 Then
                txtCodigo.Text = DataGridView1.SelectedRows(0).Cells("Codigo").Value
                txtNombre.Text = DataGridView1.SelectedRows(0).Cells("Nombre").Value
                txtDireccion.Text = DataGridView1.SelectedRows(0).Cells("Direccion").Value
                txtCiudad.Text = DataGridView1.SelectedRows(0).Cells("Ciudad").Value
                'probamos
            End If
        End If

    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "update Cliente set Codigo = '" & txtCodigo.Text & "', Nombre = '" & txtNombre.Text & "',Direccion= '" & txtDireccion.Text & "' ,Ciudad= '" & txtCiudad.Text & "' where Codigo = '" & txtCodigo.Text & "'"
            cmd.ExecuteNonQuery()
            MessageBox.Show("datos guardados")
            mostrardatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from Cliente where Codigo = '" & txtCodigo.Text & "'"
        cmd.ExecuteNonQuery()
        MessageBox.Show("datos eliminados")
        mostrardatos()

    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        limpiar()
    End Sub
    Sub limpiar()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtCiudad.Clear()

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub
End Class
