' Módulo principal para mostrar los formularios (actualizado)
Option Explicit

' Mostrar calculadora básica de fertilizantes
Sub MostrarCalculadoraBasica()
    UserForm1.Show
End Sub

' Mostrar calculadora por área
Sub MostrarCalculadoraPorArea()
    UserForm2.Show
End Sub

' Mostrar calculadora manual
Sub MostrarCalculadoraManual()
    UserForm3.Show
End Sub

' Mostrar calculadora avanzada
Sub MostrarCalculadoraAvanzada()
    UserForm4.Show
End Sub

' Mostrar comparador de cultivos
Sub MostrarComparadorCultivos()
    UserForm5.Show
End Sub

' Generar reporte completo de todos los cultivos
Sub GenerarReporteCompleto()
    Call GenerarReporteCultivos
End Sub

' Mostrar menú principal
Sub MostrarMenuPrincipal()
    Dim respuesta As Integer
    Dim mensaje As String
    
    mensaje = "CALCULADORA DE NUTRIENTES PARA CULTIVOS" & vbCrLf & vbCrLf
    mensaje = mensaje & "Selecciona una opción:" & vbCrLf & vbCrLf
    mensaje = mensaje & "1 - Calculadora Básica" & vbCrLf
    mensaje = mensaje & "2 - Calculadora por Área" & vbCrLf
    mensaje = mensaje & "3 - Calculadora Manual" & vbCrLf
    mensaje = mensaje & "4 - Calculadora Avanzada" & vbCrLf
    mensaje = mensaje & "5 - Comparador de Cultivos" & vbCrLf
    mensaje = mensaje & "6 - Generar Reporte Completo" & vbCrLf & vbCrLf
    mensaje = mensaje & "¿Qué calculadora deseas usar?"
    
    respuesta = InputBox(mensaje, "Menú Principal", "1")
    
    Select Case Val(respuesta)
        Case 1: Call MostrarCalculadoraBasica
        Case 2: Call MostrarCalculadoraPorArea
        Case 3: Call MostrarCalculadoraManual
        Case 4: Call MostrarCalculadoraAvanzada
        Case 5: Call MostrarComparadorCultivos
        Case 6: Call GenerarReporteCompleto
        Case Else: MsgBox "Opción no válida.", vbExclamation
    End Select
End Sub
