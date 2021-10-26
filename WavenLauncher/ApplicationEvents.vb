Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32

Namespace My
    ' 以下事件可用于 MyApplication: 
    ' Startup:应用程序启动时在创建启动窗体之前引发。
    ' Shutdown:在关闭所有应用程序窗体后引发。如果应用程序非正常终止，则不会引发此事件。
    ' UnhandledException:在应用程序遇到未经处理的异常时引发。
    ' StartupNextInstance:在启动单实例应用程序且应用程序已处于活动状态时引发。 
    ' NetworkAvailabilityChanged:在连接或断开网络连接时引发。
    Partial Friend Class MyApplication
        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Call WavenLauncher.DisplayForm()
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Const subkey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
            Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey)
                If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
                    If ndpKey.GetValue("Release") < 461808 Then
                        MsgBox("当前.NET框架版本过旧，请下载安装4.7.2版本方可运行本软件", MsgBoxStyle.Critical, "框架版本不符")
                        End
                    End If
                Else
                    MsgBox("未检测到.NET框架，请下载安装4.7.2版本方可运行本软件", MsgBoxStyle.Critical, "框架未找到")
                    End
                End If
            End Using
        End Sub
    End Class
End Namespace
