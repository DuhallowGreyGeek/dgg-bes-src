Module BesSrcMain
    'Start  point for the BesSrc application. Sets up things and launches the frmMain form.

    Public frmMain As New frmBesSrcMain

    Sub main()
        'Shouldn't need to do this but splash screen option of Project doesn't seem to work properly
        'Probably means I'm not doing it right!
        Dim frmSplash As New frmBesSrcSplash
        frmSplash.ShowDialog()

        'Show the Main screen
        frmMain.ShowDialog()

        'Clean up
        frmMain.Dispose()
    End Sub

End Module
