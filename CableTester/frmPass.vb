Public Class frmPass
    Dim thread As System.Threading.Thread
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub PlaySystemSound()
        'My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
        Dim i As Integer
        Do Until i = 100
            i = i + 1
            Console.Beep(1500, 500)
            Threading.Thread.Sleep(1000)
        Loop

    End Sub

    Private Sub frmPass_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        thread = New System.Threading.Thread(AddressOf PlaySystemSound)
        thread.Start()
    End Sub

    Private Sub frmPass_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        thread.Abort()
    End Sub
End Class