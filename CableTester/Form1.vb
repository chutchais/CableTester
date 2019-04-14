Public Class frmMain
    Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
        With OpenFileDialog1
            '.InitialDirectory = "C:\"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .Title = "Open a Configuraiton File (Excel)"
            .Filter = "Excel Files|*.xlsx"
            '.ShowDialog()
            Dim DidWork As Integer = .ShowDialog()
            Dim strFileName As String = ""

            If DidWork = DialogResult.Cancel Then
                'MessageBox.Show("Cancel Button Clicked")
            Else
                strFileName = .FileName
                'MessageBox.Show(strFileName)
                import_configuration(strFileName)
            End If

        End With

    End Sub

    Sub import_configuration(fileName As String)
        Try
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MasterCommand As System.Data.OleDb.OleDbDataAdapter
            Dim RecipeCommand As System.Data.OleDb.OleDbDataAdapter
            DtSet = New System.Data.DataSet

            MyConnection = New System.Data.OleDb.OleDbConnection _
            ("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & fileName & "'; Extended Properties=Excel 8.0;")

            MasterCommand = New System.Data.OleDb.OleDbDataAdapter _
                ("select * from [master$]", MyConnection)
            MasterCommand.TableMappings.Add("Table", "master")
            MasterCommand.Fill(DtSet)

            RecipeCommand = New System.Data.OleDb.OleDbDataAdapter _
                ("select * from [recipe$]", MyConnection)
            RecipeCommand.TableMappings.Add("Table", "recipe")
            RecipeCommand.Fill(DtSet)



            DataGridView1.DataSource = DtSet.Tables(0)
            DataGridView2.DataSource = DtSet.Tables(1)

            MyConnection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


End Class
