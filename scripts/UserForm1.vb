' UserForm1 - Calculadora Básica de Fertilizantes
Option Explicit

Private Sub UserForm_Initialize()
    ' Configurar el formulario
    Me.Caption = "Calculadora Básica de Fertilizantes"
    
    ' Llenar ComboBox con 20 cultivos
    With cmbCultivo
        .Clear
        .AddItem "Cacao"
        .AddItem "Café"
        .AddItem "Maíz"
        .AddItem "Arroz"
        .AddItem "Plátano"
        .AddItem "Tomate"
        .AddItem "Papa"
        .AddItem "Frijol"
        .AddItem "Soja"
        .AddItem "Trigo"
        .AddItem "Cebolla"
        .AddItem "Lechuga"
        .AddItem "Zanahoria"
        .AddItem "Algodón"
        .AddItem "Caña de azúcar"
        .AddItem "Yuca"
        .AddItem "Ñame"
        .AddItem "Aguacate"
        .AddItem "Mango"
        .AddItem "Cítricos"
    End With
    
    ' Llenar ComboBox con fertilizantes
    With cmbFertilizante
        .Clear
        .AddItem "Urea (46-00-00)"
        .AddItem "Sulfato de amonio (21-00-00)"
        .AddItem "DAP (18-46-00)"
        .AddItem "MAP (11-52-00)"
        .AddItem "KCl (00-00-60)"
        .AddItem "NPK 15-15-15"
        .AddItem "Nitrato de calcio"
        .AddItem "Superfosfato triple"
        .AddItem "Sulfato de potasio"
    End With
    
    ' Limpiar controles
    Call LimpiarFormulario
End Sub

Private Sub cmdCalcular_Click()
    On Error GoTo ErrorHandler
    
    Dim cultivo As String
    Dim edad As Double
    Dim fertilizante As String
    Dim dosis As Double
    Dim porcentaje As Double
    Dim resultado As Double
    
    ' Validar campos
    If cmbCultivo.Value = "" Then
        MsgBox "Selecciona un cultivo.", vbExclamation, "Campo requerido"
        cmbCultivo.SetFocus
        Exit Sub
    End If
    
    If cmbFertilizante.Value = "" Then
        MsgBox "Selecciona un fertilizante.", vbExclamation, "Campo requerido"
        cmbFertilizante.SetFocus
        Exit Sub
    End If
    
    If Not IsNumeric(txtEdad.Value) Or Val(txtEdad.Value) <= 0 Then
        MsgBox "Ingresa una edad válida (mayor a 0).", vbExclamation, "Valor inválido"
        txtEdad.SetFocus
        Exit Sub
    End If
    
    cultivo = cmbCultivo.Value
    fertilizante = cmbFertilizante.Value
    edad = Val(txtEdad.Value)
    
    ' Determinar etapa fisiológica y dosis base
    Select Case cultivo
        Case "Cacao", "Café"
            If edad <= 1 Then
                dosis = 40 ' Crecimiento
            ElseIf edad <= 2.5 Then
                dosis = 60 ' Floración
            Else
                dosis = 80 ' Desarrollo de fruto
            End If
        Case "Maíz", "Arroz"
            If edad <= 0.5 Then
                dosis = 50 ' Crecimiento
            ElseIf edad <= 1 Then
                dosis = 80 ' Floración
            Else
                dosis = 70 ' Desarrollo de fruto
            End If
        Case "Plátano"
            If edad <= 0.5 Then
                dosis = 60 ' Crecimiento
            ElseIf edad <= 1 Then
                dosis = 90 ' Floración
            Else
                dosis = 110 ' Desarrollo de fruto
            End If
    End Select
    
    ' Determinar % nutriente por fertilizante
    Select Case fertilizante
        Case "Urea (46-00-00)": porcentaje = 46
        Case "Sulfato de amonio (21-00-00)": porcentaje = 21
        Case "DAP (18-46-00)": porcentaje = 18
        Case "MAP (11-52-00)": porcentaje = 11
        Case "KCl (00-00-60)": porcentaje = 60
        Case "NPK 15-15-15": porcentaje = 15
        Case "Nitrato de calcio": porcentaje = 15
        Case "Superfosfato triple": porcentaje = 46
        Case "Sulfato de potasio": porcentaje = 50
        Case Else: porcentaje = 1
    End Select
    
    If porcentaje = 0 Then
        MsgBox "Porcentaje inválido para el fertilizante seleccionado.", vbExclamation
        Exit Sub
    End If
    
    ' Cálculo del fertilizante necesario por hectárea
    resultado = dosis / (porcentaje / 100)
    
    lblResultado.Caption = "Necesitas " & Format(resultado, "0.00") & " kg/ha de " & fertilizante
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error en el cálculo: " & Err.Description, vbCritical, "Error"
End Sub

Private Sub cmdBorrar_Click()
    Call LimpiarFormulario
End Sub

Private Sub LimpiarFormulario()
    cmbCultivo.Value = ""
    txtEdad.Value = ""
    cmbFertilizante.Value = ""
    lblResultado.Caption = "Resultado aparecerá aquí..."
End Sub

Private Sub cmdCerrar_Click()
    Unload Me
End Sub
