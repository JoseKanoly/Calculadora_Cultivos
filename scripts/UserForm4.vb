' UserForm4 - Calculadora Avanzada con Análisis de Suelo
Option Explicit

Private Sub UserForm_Initialize()
    Me.Caption = "Calculadora Avanzada - Análisis de Suelo"
    
    ' Cargar 20 cultivos
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
    
    ' Cargar etapas
    With cmbEtapa
        .Clear
        .AddItem "Crecimiento"
        .AddItem "Floración"
        .AddItem "Desarrollo del fruto"
    End With
    
    Call LimpiarFormulario
End Sub

Private Sub btnCalcular_Click()
    On Error GoTo ErrorHandler
    
    ' Validar campos obligatorios
    If Not ValidarCampos() Then Exit Sub
    
    Dim area As Double
    Dim nRequerido As Double, pRequerido As Double, kRequerido As Double
    Dim nSuelo As Double, pSuelo As Double, kSuelo As Double
    Dim nNecesario As Double, pNecesario As Double, kNecesario As Double
    Dim urea As Double, dap As Double, kcl As Double
    
    ' Obtener valores
    area = CDbl(txtArea.Text)
    nSuelo = CDbl(txtNSuelo.Text)
    pSuelo = CDbl(txtPSuelo.Text)
    kSuelo = CDbl(txtKSuelo.Text)
    
    ' Obtener requerimientos del cultivo
    nRequerido = ObtenerRequerimiento(cmbCultivo.Value, cmbEtapa.Value, "Nitrógeno (N)")
    pRequerido = ObtenerRequerimiento(cmbCultivo.Value, cmbEtapa.Value, "Fósforo (P2O5)")
    kRequerido = ObtenerRequerimiento(cmbCultivo.Value, cmbEtapa.Value, "Potasio (K2O)")
    
    ' Calcular nutrientes necesarios (requerido - disponible en suelo)
    nNecesario = Application.WorksheetFunction.Max(0, nRequerido - nSuelo)
    pNecesario = Application.WorksheetFunction.Max(0, pRequerido - pSuelo)
    kNecesario = Application.WorksheetFunction.Max(0, kRequerido - kSuelo)
    
    ' Calcular fertilizantes necesarios
    urea = (area * nNecesario) / 0.46  ' Urea 46% N
    dap = (area * pNecesario) / 0.46   ' DAP 46% P2O5
    kcl = (area * kNecesario) / 0.6    ' KCl 60% K2O
    
    ' Mostrar resultados
    lblNRequerido.Caption = "N requerido: " & nRequerido & " kg/ha"
    lblPRequerido.Caption = "P requerido: " & pRequerido & " kg/ha"
    lblKRequerido.Caption = "K requerido: " & kRequerido & " kg/ha"
    
    lblNNecesario.Caption = "N a aplicar: " & Format(nNecesario, "0.00") & " kg/ha"
    lblPNecesario.Caption = "P a aplicar: " & Format(pNecesario, "0.00") & " kg/ha"
    lblKNecesario.Caption = "K a aplicar: " & Format(kNecesario, "0.00") & " kg/ha"
    
    lblUreaResult.Caption = "Urea: " & Format(urea, "0.00") & " kg"
    lblDAPResult.Caption = "DAP: " & Format(dap, "0.00") & " kg"
    lblKClResult.Caption = "KCl: " & Format(kcl, "0.00") & " kg"
    
    ' Calcular y mostrar costo
    Dim costoTotal As Double
    costoTotal = (urea * CDbl(txtPrecioUrea.Text)) + (dap * CDbl(txtPrecioDAP.Text)) + (kcl * CDbl(txtPrecioKCl.Text))
    lblCostoTotal.Caption = "Costo total: $" & Format(costoTotal, "0.00")
    
    ' Generar recomendaciones
    Call GenerarRecomendaciones(nSuelo, pSuelo, kSuelo, nRequerido, pRequerido, kRequerido)
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error en el cálculo: " & Err.Description, vbCritical, "Error"
End Sub

Private Function ValidarCampos() As Boolean
    ValidarCampos = False
    
    If cmbCultivo.Value = "" Then
        MsgBox "Selecciona un cultivo.", vbExclamation
        cmbCultivo.SetFocus
        Exit Function
    End If
    
    If cmbEtapa.Value = "" Then
        MsgBox "Selecciona una etapa.", vbExclamation
        cmbEtapa.SetFocus
        Exit Function
    End If
    
    If Not IsNumeric(txtArea.Text) Or Val(txtArea.Text) <= 0 Then
        MsgBox "Ingresa un área válida.", vbExclamation
        txtArea.SetFocus
        Exit Function
    End If
    
    If Not IsNumeric(txtNSuelo.Text) Or Val(txtNSuelo.Text) < 0 Then
        MsgBox "Ingresa un valor válido para N en suelo.", vbExclamation
        txtNSuelo.SetFocus
        Exit Function
    End If
    
    If Not IsNumeric(txtPSuelo.Text) Or Val(txtPSuelo.Text) < 0 Then
        MsgBox "Ingresa un valor válido para P en suelo.", vbExclamation
        txtPSuelo.SetFocus
        Exit Function
    End If
    
    If Not IsNumeric(txtKSuelo.Text) Or Val(txtKSuelo.Text) < 0 Then
        MsgBox "Ingresa un valor válido para K en suelo.", vbExclamation
        txtKSuelo.SetFocus
        Exit Function
    End If
    
    ValidarCampos = True
End Function

Private Sub GenerarRecomendaciones(nSuelo As Double, pSuelo As Double, kSuelo As Double, _
                                 nReq As Double, pReq As Double, kReq As Double)
    Dim recomendacion As String
    
    recomendacion = "RECOMENDACIONES:" & vbCrLf & vbCrLf
    
    ' Análisis de Nitrógeno
    If nSuelo < nReq * 0.3 Then
        recomendacion = recomendacion & "• Nitrógeno: Nivel BAJO. Aplicar fertilización completa." & vbCrLf
    ElseIf nSuelo < nReq * 0.7 Then
        recomendacion = recomendacion & "• Nitrógeno: Nivel MEDIO. Aplicar fertilización moderada." & vbCrLf
    Else
        recomendacion = recomendacion & "• Nitrógeno: Nivel ALTO. Reducir aplicación." & vbCrLf
    End If
    
    ' Análisis de Fósforo
    If pSuelo < pReq * 0.3 Then
        recomendacion = recomendacion & "• Fósforo: Nivel BAJO. Aplicar fertilización completa." & vbCrLf
    ElseIf pSuelo < pReq * 0.7 Then
        recomendacion = recomendacion & "• Fósforo: Nivel MEDIO. Aplicar fertilización moderada." & vbCrLf
    Else
        recomendacion = recomendacion & "• Fósforo: Nivel ALTO. Reducir aplicación." & vbCrLf
    End If
    
    ' Análisis de Potasio
    If kSuelo < kReq * 0.3 Then
        recomendacion = recomendacion & "• Potasio: Nivel BAJO. Aplicar fertilización completa." & vbCrLf
    ElseIf kSuelo < kReq * 0.7 Then
        recomendacion = recomendacion & "• Potasio: Nivel MEDIO. Aplicar fertilización moderada." & vbCrLf
    Else
        recomendacion = recomendacion & "• Potasio: Nivel ALTO. Reducir aplicación." & vbCrLf
    End If
    
    recomendacion = recomendacion & vbCrLf & "Aplicar fertilizantes en 2-3 fracciones durante el ciclo del cultivo."
    
    txtRecomendaciones.Text = recomendacion
End Sub

Private Sub btnLimpiar_Click()
    Call LimpiarFormulario
End Sub

Private Sub LimpiarFormulario()
    ' Limpiar controles de entrada
    cmbCultivo.Value = ""
    cmbEtapa.Value = ""
    txtArea.Text = ""
    txtNSuelo.Text = ""
    txtPSuelo.Text = ""
    txtKSuelo.Text = ""
    
    ' Valores por defecto para precios
    txtPrecioUrea.Text = "0.50"
    txtPrecioDAP.Text = "0.80"
    txtPrecioKCl.Text = "0.60"
    
    ' Limpiar resultados
    lblNRequerido.Caption = "N requerido: "
    lblPRequerido.Caption = "P requerido: "
    lblKRequerido.Caption = "K requerido: "
    lblNNecesario.Caption = "N a aplicar: "
    lblPNecesario.Caption = "P a aplicar: "
    lblKNecesario.Caption = "K a aplicar: "
    lblUreaResult.Caption = "Urea: "
    lblDAPResult.Caption = "DAP: "
    lblKClResult.Caption = "KCl: "
    lblCostoTotal.Caption = "Costo total: "
    txtRecomendaciones.Text = ""
End Sub

Private Sub btnExportar_Click()
    ' Exportar resultados a una hoja de Excel
    On Error GoTo ErrorHandler
    
    Dim ws As Worksheet
    Dim ultimaFila As Long
    
    ' Crear o seleccionar hoja de resultados
    On Error Resume Next
    Set ws = ThisWorkbook.Worksheets("Resultados_Fertilizacion")
    On Error GoTo ErrorHandler
    
    If ws Is Nothing Then
        Set ws = ThisWorkbook.Worksheets.Add
        ws.Name = "Resultados_Fertilizacion"
        
        ' Crear encabezados
        With ws
            .Cells(1, 1).Value = "Fecha"
            .Cells(1, 2).Value = "Cultivo"
            .Cells(1, 3).Value = "Etapa"
            .Cells(1, 4).Value = "Área (ha)"
            .Cells(1, 5).Value = "Urea (kg)"
            .Cells(1, 6).Value = "DAP (kg)"
            .Cells(1, 7).Value = "KCl (kg)"
            .Cells(1, 8).Value = "Costo Total"
            .Range("A1:H1").Font.Bold = True
        End With
    End If
    
    ' Encontrar última fila
    ultimaFila = ws.Cells(ws.Rows.Count, 1).End(xlUp).Row + 1
    
    ' Agregar datos
    With ws
        .Cells(ultimaFila, 1).Value = Now
        .Cells(ultimaFila, 2).Value = cmbCultivo.Value
        .Cells(ultimaFila, 3).Value = cmbEtapa.Value
        .Cells(ultimaFila, 4).Value = txtArea.Text
        .Cells(ultimaFila, 5).Value = Replace(lblUreaResult.Caption, "Urea: ", "")
        .Cells(ultimaFila, 6).Value = Replace(lblDAPResult.Caption, "DAP: ", "")
        .Cells(ultimaFila, 7).Value = Replace(lblKClResult.Caption, "KCl: ", "")
        .Cells(ultimaFila, 8).Value = Replace(lblCostoTotal.Caption, "Costo total: $", "")
    End With
    
    MsgBox "Resultados exportados exitosamente a la hoja 'Resultados_Fertilizacion'.", vbInformation
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error al exportar: " & Err.Description, vbCritical
End Sub

Private Sub cmdCerrar_Click()
    Unload Me
End Sub
