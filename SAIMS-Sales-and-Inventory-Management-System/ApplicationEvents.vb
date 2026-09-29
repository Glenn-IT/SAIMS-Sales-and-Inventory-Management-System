Imports Microsoft.VisualBasic.ApplicationServices
Imports Serilog
Imports System.IO

Namespace My

    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object,
                                          e As StartupEventArgs) Handles Me.Startup
            Dim logDir As String = Path.Combine(Environment.CurrentDirectory, "logs")
            Directory.CreateDirectory(logDir)

            Serilog.Log.Logger = New LoggerConfiguration() _
                .MinimumLevel.Debug() _
                .WriteTo.File(
                    Path.Combine(logDir, "saims-.log"),
                    rollingInterval:=RollingInterval.Day,
                    outputTemplate:="{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}") _
                .CreateLogger()

            Serilog.Log.Information("Sales & Inventory Management of Rhenwas Poultry Supply application started.")

            Try
                Dim culture As System.Globalization.CultureInfo = CType(System.Globalization.CultureInfo.CurrentCulture.Clone(), System.Globalization.CultureInfo)
                culture.NumberFormat.CurrencySymbol = "₱"
                System.Globalization.CultureInfo.CurrentCulture = culture
                System.Globalization.CultureInfo.CurrentUICulture = culture
                System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture
                System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture
            Catch
                ' Fallback silently if culture cloning fails
            End Try
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object,
                                           e As EventArgs) Handles Me.Shutdown
            Serilog.Log.Information("Sales & Inventory Management of Rhenwas Poultry Supply application shut down.")
            Serilog.Log.CloseAndFlush()
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object,
                                                      e As UnhandledExceptionEventArgs) _
                                                      Handles Me.UnhandledException
            e.ExitApplication = False

            Serilog.Log.Error(e.Exception, "Unhandled exception.")

            MessageBox.Show(
                "An unexpected error occurred." &
                Environment.NewLine & Environment.NewLine &
                e.Exception.Message & Environment.NewLine & Environment.NewLine &
                "The application will continue. If this keeps happening, " &
                "please restart and contact your administrator.",
                "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Try
                ActivityLogger.Log(
                    If(String.IsNullOrEmpty(SessionManager.Username), "SYSTEM", SessionManager.Username),
                    Constants.LOG_WARNING,
                    "Unhandled exception: " & e.Exception.Message)
            Catch
                ' Swallow — logging must not cause a second crash
            End Try
        End Sub

    End Class
End Namespace
