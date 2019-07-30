﻿Imports Microsoft.VisualBasic.ApplicationServices

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
    End Class
End Namespace
